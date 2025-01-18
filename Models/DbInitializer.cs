namespace DrinkAndGo.Models
{
    public class DbInitializer
    {
        public static void Seed(IServiceProvider service)
        {
            DrinkAndGoContext context = 
                service.GetRequiredService<DrinkAndGoContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { CategoryName = "Juices", Description = "Natural and fresh juices made from fruits and vegetables." },
                    new Category { CategoryName = "Herbal Drinks", Description = "Relaxing and healthy drinks made from herbs and natural ingredients." },
                    new Category { CategoryName = "Milk-Based", Description = "Drinks that feature milk as the primary ingredient, including shakes and lattes." },
                    new Category { CategoryName = "Sparkling Non-Alcoholic", Description = "Non-alcoholic drinks with a fizzy, sparkling texture." },
                    new Category { CategoryName = "Fruit Blends", Description = "Smoothies and blended drinks made from fresh fruits." },
                    new Category { CategoryName = "Coffee", Description = "Hot and cold coffee beverages, perfect for coffee lovers." },
                    new Category { CategoryName = "Iced Drinks", Description = "Cold and refreshing drinks, perfect for hot days." },
                    new Category { CategoryName = "Hot Beverages", Description = "Warm drinks to keep you cozy and relaxed." },
                    new Category { CategoryName = "Mocktails", Description = "Non-alcoholic cocktail-style drinks for celebrations and gatherings." },
                    new Category { CategoryName = "Energy Drinks", Description = "Drinks designed to boost energy and focus." }
                );
                context.SaveChanges();
            }
            

            if (!context.Drinks.Any())
            {
                var Categories = context.Categories.ToDictionary(c => c.CategoryName, c => c);
                context.AddRange(

                    new Drink
                    {
                        Name = "Apple Juice",
                        Price = 4.50M,
                        ShortDescription = "Freshly squeezed apple juice.",
                        LongDescription = "Apple juice is a refreshing and natural beverage made from fresh apples. Perfect for any time of the day!",
                        Category = Categories["Juices"],
                        ImageUrl = "https://png.pngtree.com/png-clipart/20230414/original/pngtree-summer-orange-juice-png-image_9054080.png",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-clipart/20230414/original/pngtree-summer-orange-juice-png-image_9054080.png"
                    },
                    new Drink
                    {
                        Name = "Orange Juice",
                        Price = 5.00M,
                        ShortDescription = "A classic vitamin-packed drink.",
                        LongDescription = "Fresh orange juice squeezed from ripe oranges, rich in vitamin C and incredibly refreshing.",
                        Category = Categories["Juices"],
                        ImageUrl = "https://png.pngtree.com/png-clipart/20230414/original/pngtree-summer-orange-juice-png-image_9054080.png",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-clipart/20230414/original/pngtree-summer-orange-juice-png-image_9054080.png"
                    },
                    new Drink
                    {
                        Name = "Mint Lemonade",
                        Price = 6.00M,
                        ShortDescription = "A zesty and cool drink.",
                        LongDescription = "Mint lemonade combines the tanginess of fresh lemons with the coolness of mint leaves, making it a perfect summer drink.",
                        Category = Categories["Herbal Drinks"],
                        ImageUrl = "https://png.pngtree.com/png-clipart/20230414/original/pngtree-summer-orange-juice-png-image_9054080.png",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-clipart/20230414/original/pngtree-summer-orange-juice-png-image_9054080.png"
                    },
                    new Drink
                    {
                        Name = "Milkshake",
                        Price = 7.50M,
                        ShortDescription = "A creamy and delicious drink.",
                        LongDescription = "Milkshakes come in various flavors like chocolate, strawberry, and vanilla. A perfect treat for kids and adults alike!",
                        Category = Categories["Milk-Based"],
                        ImageUrl = "https://www.meatloafandmelodrama.com/wp-content/uploads/2024/04/strawberry-milkshake-square-1-500x500.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://www.meatloafandmelodrama.com/wp-content/uploads/2024/04/strawberry-milkshake-square-1-500x500.jpg"
                    },
                    new Drink
                    {
                        Name = "Sparkling Grape Juice",
                        Price = 8.00M,
                        ShortDescription = "A bubbly non-alcoholic treat.",
                        LongDescription = "Sparkling grape juice is a festive and fizzy drink, perfect for celebrations and gatherings.",
                        Category = Categories["Sparkling Non-Alcoholic"],
                        ImageUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png"
                    },
                    new Drink
                    {
                        Name = "Herbal Tea",
                        Price = 4.00M,
                        ShortDescription = "A soothing hot beverage.",
                        LongDescription = "Herbal tea, made from a blend of natural herbs, provides relaxation and is great for health-conscious individuals.",
                        Category = Categories["Herbal Drinks"],
                        ImageUrl = "https://png.pngtree.com/png-vector/20240224/ourmid/pngtree-fresh-herbal-tea-cup-with-mint-isolate-png-image_11875088.png",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-vector/20240224/ourmid/pngtree-fresh-herbal-tea-cup-with-mint-isolate-png-image_11875088.png"
                    },
                    new Drink
                    {
                        Name = "Strawberry Smoothie",
                        Price = 6.50M,
                        ShortDescription = "A fruity and creamy drink.",
                        LongDescription = "Strawberry smoothies are a blend of fresh strawberries and yogurt, making a nutritious and tasty option.",
                        Category = Categories["Fruit Blends"],
                        ImageUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png"
                    },
                    new Drink
                    {
                        Name = "Coconut Water",
                        Price = 3.00M,
                        ShortDescription = "A refreshing natural drink.",
                        LongDescription = "Coconut water is a low-calorie drink packed with nutrients and electrolytes, ideal for hydration.",
                        Category = Categories["Juices"],
                        ImageUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png"
                    },
                    new Drink
                    {
                        Name = "Pineapple Juice",
                        Price = 5.00M,
                        ShortDescription = "Tropical and sweet juice.",
                        LongDescription = "Fresh pineapple juice with a sweet and tangy taste, perfect for a tropical refreshment.",
                        Category = Categories["Juices"],
                        ImageUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png"
                    },
                    new Drink
                    {
                        Name = "Iced Coffee",
                        Price = 4.50M,
                        ShortDescription = "A chilled coffee delight.",
                        LongDescription = "Iced coffee is brewed coffee served cold with optional sweeteners and milk for a refreshing pick-me-up.",
                        Category = Categories["Coffee"],
                        ImageUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png"
                    },
                    new Drink
                    {
                        Name = "Green Tea",
                        Price = 3.50M,
                        ShortDescription = "A healthy hot beverage.",
                        LongDescription = "Green tea is rich in antioxidants and offers a mild flavor that soothes and refreshes.",
                        Category = Categories["Herbal Drinks"],
                        ImageUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png"
                    },
                    new Drink
                    {
                        Name = "Mango Smoothie",
                        Price = 6.50M,
                        ShortDescription = "A creamy tropical smoothie.",
                        LongDescription = "Mango smoothie made with ripe mangoes and yogurt, providing a sweet and creamy tropical taste.",
                        Category = Categories["Fruit Blends"],
                        ImageUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png"
                    },
                    new Drink
                    {
                        Name = "Chamomile Tea",
                        Price = 4.00M,
                        ShortDescription = "A calming herbal tea.",
                        LongDescription = "Chamomile tea offers a gentle floral flavor, known for its relaxing and soothing properties.",
                        Category = Categories["Herbal Drinks"],
                        ImageUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = "https://png.pngtree.com/png-vector/20240426/ourmid/pngtree-grapes-juice-in-a-glass-isolated-on-transparent-background-png-image_12315214.png"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}