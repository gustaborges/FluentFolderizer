namespace FluentFolderizer
{
    public interface IDirectoryStructurer
    {
        IDirectoryStructurer By(AudioTag tag);
        IDirectoryStructurer ThenBy(AudioTag tag);
        IOrganizerSettings Apply();
    }
}