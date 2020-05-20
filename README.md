# ZipContent.S3

Lists zip file content on Amazon Web Services S3 service without downloading whole document. Supports both zip and zip64 files.


# Usage

First install ZipContent.S3 via NuGet console:
```
PM> Install-Package ZipContent.S3
```

Sample usage:
```csharp
string bucket = "test";
string key = "foo.zip";

IAmazonS3 s3 = new AmazonS3Client();

IPartialFileReader partialReader = new S3PartialFileReader(s3, bucket, key);

IZipContentLister lister = new ZipContentLister();

var contentList = lister.GetContents(partialReader);

foreach (var content in contentList)
   Console.WriteLine(item.FullName);
 ```
