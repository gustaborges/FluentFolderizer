namespace FluentFolderizer
{
    public interface IOrganizerBuilder
    {
        IOrganizer Build();
        IOrganizerSettings ForAudioFiles();
        IOrganizerSettings ForImageFiles();
    }
}