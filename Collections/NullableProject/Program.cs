using System;

namespace NullableProject
{
    class Program
    {
        static void Main(string[] args)
        {


            // C# 8.0 features for null values




            var player1 = new PlayerCharacter(new IIronDefense());
            var player2 = new PlayerCharacter(new IDiamondDefense());
            var player3 = new PlayerCharacter(SpecialDefence.Null);

            player1.Hit(25);
            player2.Hit(30);
            player3.Hit(40);



            // PlayerCharacter[] players = new PlayerCharacter[3]
            // {
            //     new PlayerCharacter{Name = "abc"},
            //     new PlayerCharacter(),
            //     null
            // };

            // PlayerCharacter[] players1 = null;

            // string p1 = players?[0]?.Name;
            // string p2 = players?[1]?.Name;
            // string p3 = players?[2]?.Name;

            // PlayerCharacter player = new PlayerCharacter();
            // bool name = player?.IsNew ?? false;


            // Console.WriteLine($"null Coelacing operator is {name} ");
            // if (string.IsNullOrWhiteSpace(player.Name))
            // {
            //     Console.WriteLine($"player name is {player.Name}");
            // }
            //// player.IsNew = false;
            // if (player.IsNew.HasValue)
            // {
            //     Console.WriteLine($"player is New Value is {player.IsNew}");
            // }

            // if (!player.IsNew.HasValue)
            // {
            //     Console.WriteLine($"player is New Value is {player.IsNew.GetValueOrDefault()}");
            // }

            // int? i = null;
            // int j = 43;

            // int? v = i.HasValue ? i : j;


            // Console.WriteLine($"conditional operator value is {v} ");


            // int? a = 2;
            // int b = 43;

            // int? c = a ?? b;


            // Console.WriteLine($"null Coelacing operator is {c} ");




        }
    }
}
