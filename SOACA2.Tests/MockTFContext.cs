using Microsoft.EntityFrameworkCore;
using SOACA2.Models;

namespace SOACA2.SOACA2.Tests
{
    public static class MockTFContext
    {
        public static TFContext Create()
        {
            var options = new DbContextOptionsBuilder<TFContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            var context = new TFContext(options);

            // Seed data
            context.Characters.AddRange(
                new Character { id = 1, name = "Scout", description= "The youngest of eight boys from the south side of Boston, the Scout learned early how to solve problems with his fists. With seven older brothers on his side, fights tended to end before the runt of the litter could maneuver into punching distance, so the Scout trained himself to run. He ran everywhere, all the time, until he could beat his pack of mad dog siblings to the fray.", role = "Offensive" },
                new Character { id = 2, name = "Soldier", description= "Though he wanted desperately to fight in World War 2, the Soldier was rejected from every branch of the U.S. military. Undaunted, he bought his own ticket to Europe. After arriving and finally locating Poland, the Soldier taught himself how to load and fire a variety of weapons before embarking on a Nazi killing spree for which he was awarded several medals that he designed and made himself. His rampage ended immediately upon hearing about the end of the war in 1949", role = "Offensive" },
                new Character { id = 3, name = "Medic", description= "What he lacks in compassion for the sick, respect for human dignity, and any sort of verifiable formal training in medicine, the Medic more than makes up for with a bottomless supply of giant needles and a trembling enthusiasm for plunging them into exposed flesh. Raised in Stuttgart, Germany during an era when the Hippocratic oath had been downgraded to an optional Hippocratic suggestion, the Medic considers healing a generally unintended side effect of satisfying his own morbid curiosity. ", role = "Support" }
            );

            context.Weapons.AddRange(
                new Weapon { id = 1, name = "Rocket Launcher", CharacterId = 2 },
                new Weapon { id = 2, name = "Medi Gun", CharacterId = 3 }
            );

            context.SaveChanges();
            return context;
        }
    }
}
