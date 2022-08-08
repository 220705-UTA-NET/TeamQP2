using System.Text;
using System.Text.Json;

namespace GameReviewAPI.APP
{
    class Program {
        public static readonly HttpClient client = new HttpClient();
        private static string baseURI = "https://localhost:7100/api";
        static async Task Main(){
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("What would you like to do? Please select number: ");
                Console.WriteLine("Games:");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("1) List all games in Database");
                Console.WriteLine("2) List all games in Database by a certain developer");
                Console.WriteLine("3) List all games in Database by a certain genre");
                Console.WriteLine("4) Insert a game into Database\n");
                Console.WriteLine("Reviewer:");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("5) List all reviewers in Database");
                Console.WriteLine("6) Find a reviewer by id in Database");
                Console.WriteLine("7) Insert a new reviewer into the Database\n");
                Console.WriteLine("Reviews:");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("8) List all reviews in Database");
                Console.WriteLine("9) List average ratings in Database by descending order");
                Console.WriteLine("10) List average ratings in Database by ascending order");
                Console.WriteLine("11) List all reviews from a specific user in the database");
                Console.WriteLine("12) List all reviews for a specific game in the database");
                Console.WriteLine("13) Insert a review into the database");
                Console.WriteLine("14) Delete a review from the database\n");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("15) Exit Program");
                string userResponse = Console.ReadLine();
                switch (userResponse)
                {
                    case "1":
                        Console.WriteLine("Retrieving games from database\n");
                        string gameResponse = await client.GetStringAsync(baseURI + "/Game");
                        List<Game> games = JsonSerializer.Deserialize<List<Game>>(gameResponse);
                        Console.Clear();
                        foreach (var item in games)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine("Which developer would you like to search for?\n");
                        string developerUserResponse = Console.ReadLine();
                        string developerResponse = await client.GetStringAsync(baseURI + $"/Game/Developer?developer={developerUserResponse}");
                        List<Game> gamesByDeveloper = JsonSerializer.Deserialize<List<Game>>(developerResponse);
                        Console.Clear();
                        foreach (var item in gamesByDeveloper)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine("Which Genre would you like to search for?\n");
                        string genreUserResponse = Console.ReadLine();
                        string genreResponse = await client.GetStringAsync(baseURI + $"/Game/Genre?genre={genreUserResponse}");
                        List<Game> gamesByGenre = JsonSerializer.Deserialize<List<Game>>(genreResponse);
                        Console.Clear();
                        foreach (var item in gamesByGenre)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine("What is the title of the game?");
                        string title = Console.ReadLine();
                        Console.WriteLine("\nWho is the developer of the game?");
                        string developer = Console.ReadLine();
                        Console.WriteLine("\nWhat is the genre of the game?");
                        string genre = Console.ReadLine();
                        Console.WriteLine("\nWhat year was the game published?");
                        int year = int.Parse(Console.ReadLine());
                        Game game = new Game(title, developer, genre, year);
                        var content = new StringContent(JsonSerializer.Serialize(game), Encoding.UTF8, "application/json");
                        await client.PostAsync(baseURI + $"/Game/insertGame",content);
                        Console.Clear();
                        Console.WriteLine("Game successfully inserted!\n");
                        break;
                    case "5":
                        Console.WriteLine("Retrieving reviewers in the database\n");
                        string reviewerResponse = await client.GetStringAsync(baseURI + "/Reviewer");
                        List<Reviewer> reviewers = JsonSerializer.Deserialize<List<Reviewer>>(reviewerResponse);
                        Console.Clear();
                        foreach (var item in reviewers)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                        break;
                    case "6":
                        Console.WriteLine("What is the ID of the user you are looking for?\n");
                        int response = int.Parse(Console.ReadLine());
                        string reviewerIDResponse = await client.GetStringAsync(baseURI + $"/Reviewer/byID?id={response}");
                        Console.Clear();
                        Console.WriteLine(reviewerIDResponse);
                        Console.WriteLine();
                        break;
                    case "7":
                        Console.WriteLine("What is the UserID of the reviewer?");
                        string userID = Console.ReadLine();
                        Console.WriteLine("\nWhat is the password of the reviewer?");
                        string password = Console.ReadLine();
                        Reviewer reviewer = new Reviewer(userID, password);
                        var reviewerContent = new StringContent(JsonSerializer.Serialize(reviewer), Encoding.UTF8, "application/json");
                        await client.PostAsync(baseURI + $"/Reviewer/insertReviewer", reviewerContent);
                        Console.Clear();
                        Console.WriteLine("Successfully Inserted Reviewer\n");
                        break;
                    case "8":
                        Console.WriteLine("Listing all reviews in the database\n");
                        string reviewsResponse = await client.GetStringAsync(baseURI + "/Reviews");
                        List<Review> reviews = JsonSerializer.Deserialize<List<Review>>(reviewsResponse);
                        Console.Clear();
                        foreach (var item in reviews)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                        break;
                    case "9":
                        Console.WriteLine("Retrieving average ratings in descending order\n");
                        string descendingResponse = await client.GetStringAsync(baseURI + "/Reviews/Descending");
                        List<AverageReview> descendingReviews = JsonSerializer.Deserialize<List<AverageReview>>(descendingResponse);
                        Console.Clear();
                        foreach (var item in descendingReviews)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                        break;
                    case "10":
                        Console.WriteLine("Retrieving average ratings in ascending order\n");
                        string ascendingResponse = await client.GetStringAsync(baseURI + "/Reviews/Ascending");
                        List<AverageReview> ascendingReviews = JsonSerializer.Deserialize<List<AverageReview>>(ascendingResponse);
                        Console.Clear();
                        foreach (var item in ascendingReviews)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                        break;
                    case "11":
                        Console.WriteLine("What is the reviewer's ID?\n");
                        int idResponse = int.Parse(Console.ReadLine());
                        string reviewsIdResponse = await client.GetStringAsync(baseURI + $"/Reviews/byID?ID={idResponse}");
                        List<Review> reviewsByID = JsonSerializer.Deserialize<List<Review>>(reviewsIdResponse);
                        Console.Clear();
                        foreach (var item in reviewsByID)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                        break;
                    case "12":
                        Console.WriteLine("What is the title of the game?\n");
                        string gameTitle = Console.ReadLine();
                        string reviewsTitleResponse = await client.GetStringAsync(baseURI + $"/Reviews/gameReview?game={gameTitle}");
                        List<GameReview> reviewsByTitle = JsonSerializer.Deserialize<List<GameReview>>(reviewsTitleResponse);
                        Console.Clear();
                        foreach (var item in reviewsByTitle)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                        break;
                    case "13":
                        Console.WriteLine("What would you like to say about the game?");
                        string review = Console.ReadLine();
                        Console.WriteLine("\nWhat star rating would you like to give? (1-5)");
                        int stars = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nWhat is your ID");
                        int reviewerID = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nWhat is the game's ID");
                        int gameID = int.Parse(Console.ReadLine());
                        Review userReview = new Review(review, stars, reviewerID, gameID, DateTime.Now);
                        var reviewContent = new StringContent(JsonSerializer.Serialize(userReview), Encoding.UTF8, "application/json");
                        await client.PostAsync(baseURI + $"/Reviews/insertReview", reviewContent);
                        Console.Clear();
                        Console.WriteLine("Successfully inserted review\n");
                        break;
                    case "14":
                        Console.WriteLine("What is the ID of the reviewer?");
                        int deleteUserReviewID = int.Parse(Console.ReadLine());
                        Console.WriteLine("What is the ID of the game the review is on?");
                        int deleteGameReviewID = int.Parse(Console.ReadLine());
                        await client.DeleteAsync(baseURI + $"/Reviews/deleteReview?reviewerID={deleteUserReviewID}&gameID={deleteGameReviewID}");
                        Console.Clear();
                        Console.WriteLine("Successfully deleted review\n");
                        break;
                    case "15":
                        Console.WriteLine("exiting program");
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Input not understood. Please enter a valid option");
                        break;
                }
                
            }
        }
}
    }