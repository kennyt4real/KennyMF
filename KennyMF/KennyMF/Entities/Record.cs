using KennyMF.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace KennyMF.Entities
{
    public class Record : BaseEntity
    {
        public long FormId { get; set; }
        public string ResponseJson { get; set; }
        public RecordStatus RecordStatus{get;set;}
        public long TeamId { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public SubmissionStatus SubmissionStatus { get; set; }
        public string Message { get; set; }
        public long ApiRecordId { get; set; }
        public JObject ResponseJObject => JsonConvert.DeserializeObject<JObject>(ResponseJson);
        public bool HasSmilePhoto { get; set; }
        public string SmileUserTag { get; set; }
    }
}
