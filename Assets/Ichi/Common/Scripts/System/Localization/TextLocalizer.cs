using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;
using UnityEngine.Localization.SmartFormat;

namespace Ichi.Common
{
    public class TextLocalizer : ITextLocalizer
    {
        private string table;

        public TextLocalizer(string table) {
            this.table = table;
        }

        public string Localize(string key, params object[] values) {
            return new LocalizedStringTable(this.table)
                .GetTable()
                .GetEntry(key)
                .GetLocalizedString(values);
        }
    }
}
