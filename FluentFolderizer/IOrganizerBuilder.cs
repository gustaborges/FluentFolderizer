namespace FluentFolderizer
{
    public interface IOrganizerBuilder
    {
        IOrganizerSettings ForAudioFiles();
        IOrganizerSettings ForImageFiles();
    }
}