string path = @"C:\teste\";

DirectoryInfo dir = new DirectoryInfo(path);

foreach (FileInfo file in dir.GetFiles())
{
    int count = 0;

    using (StreamReader reader = new StreamReader(file.FullName))
    {
        while (!reader.EndOfStream)
        {
            reader.ReadLine();
            count++;
        }
    }

    if (count == 2)
    {
        File.Delete(file.FullName);
    }
}