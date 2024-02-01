using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SettingEntity:BaseEntity
    {
        public string? Email { set; get; }
        public string? Number { set; get; }
        public string? SiteTitle { set; get; }
        public string? Instagram { set; get; }
        public string? Telegram { set; get; }
        public string? WhatsApp { set; get; }
        public string? SmsKey { set; get; }
        public string? Help { set; get; }
        public string? Law { set; get; }
        public string? Enamad { set; get; }
        public string? About { set; get; }
    }
}
