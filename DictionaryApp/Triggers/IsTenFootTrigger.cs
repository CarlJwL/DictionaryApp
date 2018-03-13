using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
using Windows.UI.Xaml;

namespace DictionaryApp.Triggers
{
    class IsTenFootTrigger : StateTriggerBase
    {
        private bool _isTenFootRequested;

        public IsTenFootTrigger()
        {
            // Set default values.
            IsTenFoot = true;
        }

        public bool IsTenFoot
        {
            get
            {
                return _isTenFootRequested;
            }
            set
            {
                _isTenFootRequested = value;
                SetActive(SystemInformationHelpers.IsTenFootExperience == _isTenFootRequested);
            }
        }
    }
    public class SystemInformationHelpers
    {
        // Calculate this once and cache the result.
        private static bool _isXbox = (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Xbox");

        // For now, the 10-foot experience is enabled only on Xbox.
        public static bool IsTenFootExperience => _isXbox;
    }
}
