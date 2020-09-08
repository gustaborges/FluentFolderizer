namespace FluentFolderizer
{
    public interface IOrganizerSettings
    {
        IOrganizerSettings LocatedIn(string path, bool recursive);
        IOrganizerSettings OrganizeInto(string path);
        IOrganizerSettings HandleFilesBy(FileHandling fileHandling);
        IDirectoryStructurer Organize();
        IOrganizerSettings Build();
    }
}