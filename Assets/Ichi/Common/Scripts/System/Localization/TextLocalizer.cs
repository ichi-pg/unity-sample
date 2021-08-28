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
        private StringTable table;

        public TextLocalizer(string table) {
            this.table = new LocalizedStringTable(table).GetTable();
        }

        public string Localize(string key, params object[] values) {
            return this.table.GetEntry(key).GetLocalizedString(values);
        }
    }
}
