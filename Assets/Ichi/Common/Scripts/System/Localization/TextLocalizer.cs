using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;
using UnityEngine.Localization.SmartFormat;

namespace Ichi.Common
{
    public class TextLocalizer : ITextLocalizer
    {
        private LocalizedStringTable table;

        public TextLocalizer(string table) {
            this.table = new LocalizedStringTable(table);
        }

        public string Localize(string key, params object[] values) {
            if (key == "") {
                return "";
            }
            return this.table.GetTable().GetEntry(key).GetLocalizedString(values);
        }
    }
}
