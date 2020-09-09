using FluentFolderizer.Tags;

namespace FluentFolderizer.Audio
{
    public interface IAudioDirectoryStructurer
    {
        IAudioDirectoryStructurer By(AudioTag tag);
        IAudioDirectoryStructurer ThenBy(AudioTag tag);
        IOrganizerSettings Apply();
    }
}