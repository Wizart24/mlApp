namespace MLAppAPI.Models
{
    public class DataFile
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[] FileData { get; set; }
        public string DataType { get; set; }
        public string Description { get; set; }

        public DataFile()
        {
            
        }

        public DataFile(Guid id, string title, DateTime createdDate, byte[] fileData, string dataType, string description)
        {
            Id = id;
            Title = title;
            CreatedDate = createdDate;
            FileData = fileData;
            DataType = dataType;
            Description = description;
        }
    }
}
