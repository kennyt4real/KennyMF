using System;
using System.Collections.Generic;
using System.Text;

namespace KennyMF.Interface
{
    public interface IUIControl
    {
        bool Visible { get; set; }
        int Position { get; set; }
        bool Required { get; set; }
        string FieldId { get; }
        object Result { get; }
        bool ResultValid { get; }
        void SetResult(object value);
        void ClearResult();
    }
}
