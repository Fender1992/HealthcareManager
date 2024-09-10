namespace HealthcareManager.Data.Models
{
    public class SelectListModel
    {
        public string Text { get; set; }
        public string Abbreviation { get; set; } = "";
        public int? Value { get; set; }
        public string? TextValue { get; set; }
        public int? Order { get; set; }
        public string GroupValue { get; set; }
        public static SelectListModel ToModel(string _Name, string _Description, string _Abbreviation, int _Value, bool _ShowName, int? _Order, bool _ShowNameAndDescription = false, bool _ShowAbbreviation = false)
        {
            SelectListModel model = new SelectListModel
            {
                Value = _Value,
                Order = _Order
            };
            if (_ShowNameAndDescription)
            {
                model.Text = $"{_Name} - {_Description}";
            }
            else if (_ShowAbbreviation)
            {
                model.Text = $"{_Abbreviation} - {_Name}";
            }
            if (_ShowName)
            {
                model.Text = _Name;
            }
            else
            {
                model.Text = _Description;
            }
            if(_Abbreviation is not null)
                model.Abbreviation = _Abbreviation;
            return model;
        }
    }
    public class HealthcareFacilitySelectListModel : SelectListModel
    {
        public string ParentValue { get; set; }
    }
}
