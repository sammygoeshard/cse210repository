using System;

class Program
{
    static void Main(string[] args)
    
    {

        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        // video List
        List<Video> videos = new List<Video>();

        
        // Video 1 + Comments
        
        Video v1 = new Video("introduction to C# and Object-Oriented Programming", "Csv Javi", 485);
        
        v1.AddComment(new Comment("bobRoss", "This explains it pretty well. Thanks!"));
        v1.AddComment(new Comment("Shaq", "Nice examples. Please do encapsulation next."));
        v1.AddComment(new Comment("John", "Short and direct. I like it."));
        videos.Add(v1);

        
        // Video 2 + Comments
    
        Video v2 = new Video("logic & loops in C#", "CodeWithLiam", 430);
        v2.AddComment(new Comment("Zuleima", "Loops were my worst nightmare, but this helped a lot."));
        v2.AddComment(new Comment("akinozama", "still confuses me a bit lol"));
        v2.AddComment(new Comment("Crophead", "Can you do a video on arrays next?"));
        videos.Add(v2);

      
        // Video 3 + Comments
      
        Video v3 = new Video("CSS Grid explained in 10 minutes", "Gigacode", 540);
        v3.AddComment(new Comment("Ada", "Grid is easier than I thought."));
        v3.AddComment(new Comment("Clem", "The layout section was gold."));
        v3.AddComment(new Comment("Flex", "Can you do Flexbox vs Grid next?"));
        videos.Add(v3);

        

        // Display all videos + comments
       
        foreach (Video video in videos)
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine("====================================");
            Console.WriteLine();
        }
    }
}
