using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB
{
    public class Enums
    {
        public enum Preferences
        {
            [EnumName("List Count")]
            ListCount = 1,

            [EnumName("Theme Color")]
            ThemeColor,

            [EnumName("Touch Sound Enabled")]
            TouchSoundEnabled,
        }

        public enum ApiSource
        {
            [EnumName("")]
            OMDb,
            TMDB,
            TMS,
            TVMaze
        }
    }
}
