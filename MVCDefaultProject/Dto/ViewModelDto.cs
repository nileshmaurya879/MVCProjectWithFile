namespace MVCDefaultProject.Dto
{
    public class ViewModelDto
    {
        public List<checkboxOptions> checkboxes { get; set; }
    }

    public class checkboxOptions {
        public bool isSelected{ get; set; }
        public string text{ get; set; }
        public string value{ get; set; }
    }
}
