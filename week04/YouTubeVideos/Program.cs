using System;

class Program
{
    static void Main(string[] args)
    
    {

        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        // Create list of videos
        List<Video> videos = new List<Video>();

        
        // Video 1 + Comments
        
        Video v1 = new Video("C# Abstraction Explained Simply", "Csv Javi", 485);
        
        v1.AddComment(new Comment("bobRoss", "This finally made abstraction clear. Thanks!"));
        v1.AddComment(new Comment("Shaq", "Nice examples. Please do encapsulation next."));
        v1.AddComment(new Comment("John", "Short and direct. I like it."));
        videos.Add(v1);

        
        // Video 2 + Comments
    
        Video v2 = new Video("JavaScript Array Methods: map, filter, reduce", "CodeWithLiam", 720);
        v2.AddComment(new Comment("Zuleima", "map() clicked instantly from your example."));
        v2.AddComment(new Comment("akinozama", "reduce() still confuses me a bit lol"));
        v2.AddComment(new Comment("Crophead", "Very helpful breakdown!"));
        videos.Add(v2);

      
        // Video 3 + Comments
      
        Video v3 = new Video("CSS Grid explained in 10 minutes", "Gigachad", 540);
        v3.AddComment(new Comment("Ada", "Grid is easier than I thought."));
        v3.AddComment(new Comment("Femi", "The layout section was gold."));
        v3.AddComment(new Comment("Chioma", "Can you do Flexbox vs Grid next?"));
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
