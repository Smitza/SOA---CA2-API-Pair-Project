﻿using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace SOACA2.Models
{

    public class TFContext: DbContext
    {
        public TFContext(DbContextOptions<TFContext> options) : base(options) { }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Cosmetic> Cosmetics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Relationships between classes and weapons
            modelBuilder.Entity<Character>()
                .HasMany(e => e.Weapons)
                .WithOne(e => e.Character)
                .HasForeignKey(e => e.CharacterId)
                .HasPrincipalKey(e => e.id);

            //Relationships between classes and cosmetics
            modelBuilder.Entity<Character>()
                .HasMany(e => e.Cosmetics)
                .WithOne(e => e.Character)
                .HasForeignKey(e => e.CharacterId)
                .HasPrincipalKey(e => e.id);


            //Seeding character data
            modelBuilder.Entity<Character>().HasData(
                new Character()
                {
                    id = 1,
                    name = "Scout",
                    description = "The youngest of eight boys from the south side of Boston, the Scout learned early how to solve problems with his fists. With seven older brothers on his side, fights tended to end before the runt of the litter could maneuver into punching distance, so the Scout trained himself to run. He ran everywhere, all the time, until he could beat his pack of mad dog siblings to the fray.",
                    abilities = "Double Jump",
                    health = 125,
                    speed = 17,
                    role = "Offensive"

                },
                new Character()
                {
                    id = 2,
                    name = "Soldier",
                    description = "Though he wanted desperately to fight in World War 2, the Soldier was rejected from every branch of the U.S. military. Undaunted, he bought his own ticket to Europe. After arriving and finally locating Poland, the Soldier taught himself how to load and fire a variety of weapons before embarking on a Nazi killing spree for which he was awarded several medals that he designed and made himself. His rampage ended immediately upon hearing about the end of the war in 1949",
                    abilities = "Rocket Jump",
                    health = 200,
                    speed = 10.2,
                    role = "Offensive"
                },
                new Character()
                {
                    id = 3,
                    name = "Pyro",
                    description = "Only two things are known for sure about the mysterious Pyro: he sets things on fire and he doesn't speak. In fact, only the part about setting things on fire is undisputed. Some believe his occasional rasping wheeze may be an attempt to communicate through a mouth obstructed by a filter and attached to lungs ravaged by constant exposure to his asbestos-lined suit. Either way, he's a fearsome, inscrutable, on-fire Frankenstein of a man - if he even is a man.",
                    abilities = " Afterburn immunity",
                    health = 175,
                    speed = 12.8,
                    role = "Offensive"
                },
                new Character()
                {
                    id = 4,
                    name = "Demoman",
                    description = "A fierce temper, a fascination with all things explosive, and a terrible plan to kill the Loch Ness Monster cost the six year old Demoman his original set of adoptive parents. Later, at the Crypt Grammar School for Orphans near Ullapool in the Scottish Highlands, the boy's bomb-making skills improved dramatically. His disposition and total number of intact eyeballs, however, did not. ",
                    abilities = "Stickybomb jump",
                    health = 175,
                    speed = 17,
                    role = "Defensive"
                },
                new Character()
                {
                    id = 5,
                    name = "Heavy",
                    description = "Like a hibernating bear, the Heavy appears to be a gentle giant. Also like a bear, confusing his deliberate, sleepy demeanor with gentleness will get you ripped limb from limb. Though he speaks simply and moves with an economy of energy that's often confused with napping, the Heavy isn't dumb; he's not your big friend and he generally wishes that you would just shut up before he has to make you shut up. ",
                    abilities = "Knockback resistance",
                    health = 300,
                    speed = 9.8,
                    role = "Defensive"
                },
                new Character()
                {
                    id = 6,
                    name = "Engineer",
                    description = "This amiable, soft-spoken good ol' boy from tiny Bee Cave, Texas loves barbeque, guns, and higher education. Natural curiosity, ten years as a roughneck in the west Texas oilfields, and eleven hard science PhDs have trained him to design, build and repair a variety of deadly contraptions. ",
                    abilities = "Sentry building",
                    health = 125,
                    speed = 12.8,
                    role = "Defensive"
                },
                new Character()
                {
                    id = 7,
                    name = "Medic",
                    description = "What he lacks in compassion for the sick, respect for human dignity, and any sort of verifiable formal training in medicine, the Medic more than makes up for with a bottomless supply of giant needles and a trembling enthusiasm for plunging them into exposed flesh. Raised in Stuttgart, Germany during an era when the Hippocratic oath had been downgraded to an optional Hippocratic suggestion, the Medic considers healing a generally unintended side effect of satisfying his own morbid curiosity. ",
                    abilities = "Health regeneration",
                    health = 150,
                    speed = 13.6,
                    role = "Support"
                },
                new Character()
                {
                    id = 8,
                    name = "Sniper",
                    description = "Half rugged outdoorsman, half alien observer, this taciturn strip of beef jerky has spent the better part of his life alone in the bush, slow baking under the Australian sun. ",
                    health = 125,
                    speed = 12.8,
                    role = "Support"
                },
                new Character()
                {
                    id = 9,
                    name = "Spy",
                    description = "He is a puzzle, wrapped in an enigma, shrouded in riddles, lovingly sprinkled with intrigue, express mailed to Mystery, Alaska, and LOOK OUT BEHIND YOU! but it is too late. You're dead. For he is the Spy - globetrotting rogue, lady killer (metaphorically) and mankiller (for real). ",
                    abilities = "Invisibility, Disguise",
                    health = 125,
                    speed = 13.6,
                    role = "Support"
                });


            //Seeding weapon data
            modelBuilder.Entity<Weapon>().HasData(

                // Data to add if there is enough time.

                
                // Scout weapons primary non-main
                //new Weapons() { name = "Force-A-Nature", type = "Force-A-Nature", dmg = 113, description = "The Force-A-Nature, also known as the FaN, is an unlockable primary weapon for the Scout. It is a large double-barreled hunting shotgun with sawn-off barrels and a wooden stock and foregrip." },
                //new Weapons() { name = "Shortstop", type = "Shortstop", dmg = 72, description = "The Shortstop is a community-created primary weapon for the Scout. It is a four-barreled derringer-style peppergun fitted with pearl grips." },
                //new Weapons() { name = "Soda Popper", type = "Soda Popper", dmg = 105, description = "The Soda Popper is a community-created primary weapon for the Scout. It is a broken break-action double-barrelled shotgun featuring three black bands around the stock and front, one black band around the slitted barrel, and a band near the trigger guard. A can of Crit-a-Cola is fitted underneath fixed into place with bands as a makeshift handguard." },
                //new Weapons() { name = "Baby Face's Blaster", type = "Baby Face's Blaster", dmg = 105, description = "The Baby Face's Blaster is a community-created primary weapon for the Scout. It is a short, slightly modified lever-action shotgun with a wooden handle, small drum magazine and a single barrel." },
                //new Weapons() { name = "Back Scatter", type = "Back Scatter", dmg = 105, description = "The Back Scatter is a community-created primary weapon for the Scout. It is a short, slightly-modified lever-action shotgun with wooden grips, a single barrel, and two small shell drums on the sides." },


                // Muti-class weapons
                new Weapon() { id = 1, name = "Shotgun", type = "Shotgun", dmg = 90, description = "The Shotgun is the default secondary weapon for the Soldier, Pyro, and Heavy, and the default primary weapon for the Engineer. It is a pump-action, sawed-off shotgun. " },
                new Weapon() { id = 2, name = "Pistol", type = "Pistol", dmg = 15, description = "The Pistol boasts only a small amount of damage per hit, however, its high rate of fire makes its overall damage output relatively substantial if multiple consecutive shots are landed." },


                // Scout weapons
                new Weapon() { id = 3, name = "Scattergun", type = "Scattergun", dmg = 105, description = "The Scattergun is the default primary weapon for the Scout. It is a short, double-barreled, lever-action shotgun with a wooden handle and foregrip.", CharacterId = 1 },
                new Weapon() { id = 4, name = "Bat", type = "Melee", dmg = 35, description = "The Bat is the default melee weapon for the Scout. It is an aluminium baseball bat with rubber grip tape, a faded green-ish blue label, and a large dent on one side.", CharacterId = 1 },


                // Soldier weapons
                new Weapon() { id = 5, name = "Rocket Launcher", type = "Rocket Launcher", dmg = 90, description = "The Rocket Launcher is the default primary weapon for the Soldier. It is a stylized rocket-launching device with wooden grips, a large front sight, and a wide exhaust port.", CharacterId = 2 },
                new Weapon() { id = 6, name = "Shovel", type = "Melee", dmg = 65, description = "The Shovel is the default melee weapon for the Soldier. It is a stylized hand-held entrenching tool with a splintered handle. ", CharacterId = 2 },

                // Pyro weapons
                new Weapon() { id = 7, name = "Flame Thrower", type = "Flame Thrower", dmg = 150, description = "The Flame Thrower is the default primary weapon for the Pyro. It is a long metal pole, connected by a hose to a propane tank. The tank is attached to the pole via fastening bands. A continually lit pilot light can be seen at the nozzle. The trigger is made out of a team-colored gas pump handle.", CharacterId = 3 },
                new Weapon() { id = 8, name = "Fire Axe", type = "Melee", dmg = 65, description = "The Fire Axe is the default melee weapon for the Pyro. It is a firefighter's axe with a red axe-head, unpainted blade, and a plain wooden handle. ", CharacterId = 3 },

                // Demoman weapons
                new Weapon() { id = 9, name = "Grenade Launcher", type = "Grenade Launcher", dmg = 100, description = "The Grenade Launcher is the default primary weapon for the Demoman. It is a stylized revolving, break-action grenade launcher with adjustable sights and a wooden stock and foregrip. ", CharacterId = 4 },
                new Weapon() { id = 10, name = "Stickybomb Launcher", type = "Stickybomb Launcher", dmg = 120, description = "The Stickybomb Launcher is the default secondary weapon for the Demoman. It is a modified grenade launcher with a large olive drum magazine, an under-barrel foregrip, and a wide barrel. A charging handle used to reload the weapon sits on the back left side, above the trigger. ", CharacterId = 4 },
                new Weapon() { id = 11, name = "Bottle", type = "Melee", dmg = 65, description = "The Bottle is the default melee weapon for the Demoman. It is a brown, opaque glass bottle of scrumpy marked with 'XXX' on the label and the year '1808'. ", CharacterId = 4 },

                // Heavy weapons
                new Weapon() { id = 12, name = "Minigun", type = "Minigun", dmg = 9, description = "The Minigun, known affectionately as 'Sasha' is the default primary weapon for the Heavy. It is an enormous Gatling-style machine gun with a large rotating barrel, complete with a large white underslung ammunition case and two handles. ", CharacterId = 5 },
                new Weapon() { id = 13, name = "Fists", type = "Melee", dmg = 65, description = "The Fists are the default melee weapon for the Heavy. They are the Heavy's large, meaty hands wearing fingerless gloves and curled into deadly weapons. ", CharacterId = 5 },

                // Engineer weapons
                new Weapon() { id = 14, name = "Wrench", type = "Melee", dmg = 65, description = "The Wrench, also known as the Uhlman Build-Matic Wrench, is the default melee weapon for the Engineer. It is a monkey wrench with an antique design. ", CharacterId = 6 },

                 // Medic weapons
                 new Weapon() { id = 15, name = "Syringe Gun", type = "Syringe Gun", dmg = 10, description = "The Syringe Gun is the default primary weapon for the Medic. It is a custom-built stylized gun that uses air pressure to fire syringes from a transparent cylindrical case.  ", CharacterId = 7 },
                 new Weapon() { id = 16, name = "Medi Gun", type = "Medi Gun", dmg = 0, description = "The Medi Gun is the default secondary weapon for the Medic. It is a modified team-colored fire hose nozzle wrapped in black tape and outfitted with a bottom handle, which is connected to the Medic's backpack by a hose.", CharacterId = 7 },
                 new Weapon() { id = 17, name = "Bonesaw", type = "Melee", dmg = 65, description = "The Bonesaw is the default melee weapon for the Medic. It is a worn, large-toothed medical saw with a thick grey handle, similar to those that were once used during operations and amputations. ", CharacterId = 7 },

                 // Sniper weapons
                 new Weapon() { id = 18, name = "Sniper Rifle", type = "Sniper Rifle", dmg = 150, description = "The Sniper Rifle is the default primary weapon for the Sniper. It is a single-shot, bolt-action rifle with a wooden stock and a massive telescopic scope, with a laser sight attached underneath. ", CharacterId = 8 },
                 new Weapon() { id = 19, name = "SMG", type = "SMG", dmg = 8, description = "The Medi Gun is the default secondary weapon for the Medic. It is a modified team-colored fire hose nozzle wrapped in black tape and outfitted with a bottom handle, which is connected to the Medic's backpack by a hose.", CharacterId = 8 },
                 new Weapon() { id = 20, name = "Kukri", type = "Melee", dmg = 65, description = "The Kukri is the default melee weapon for the Sniper. It is a large kukri with a brown handle and a bit of its blade chipped off. ", CharacterId = 8 },

                 // Spy weapons
                 new Weapon() { id = 21, name = "Revolver", type = "Revolver", dmg = 40, description = "The Revolver is the default secondary weapon for the Spy. It is a stylized double-action, six-shot revolver with ivory grips and a swing-out cylinder. ", CharacterId = 9 },
                 new Weapon() { id = 22, name = "Knife", type = "Melee", dmg = 10000, description = "The Knife, also known as the Butterfly Knife or Balisong, is the default melee weapon for the Spy. It is a foldable stylized butterfly knife with a handle clip and clip-point blade. ", CharacterId = 9 }
            );

            //seeding cosmetic data
            modelBuilder.Entity<Cosmetic>().HasData(
                //Scout Cosmetics
                new Cosmetic() { id = 1, name = "Batter's Helmet", type = "Hat", CharacterId = 1},
                new Cosmetic() { id = 2, name = "Cool Cat Cardigan", type = "Shirt", CharacterId = 1 },
                //Soldier Cosmetics
                new Cosmetic() { id = 3, name = "Soldier's Stash", type = "Hat", CharacterId = 2 },
                new Cosmetic() { id = 4, name = "Hornblower", type = "Shirt", CharacterId = 2 },
                //Pyro Cosmetics
                new Cosmetic() { id = 5, name = "Brigade Helm", type = "Hat", CharacterId = 3 },
                new Cosmetic() { id = 6, name = "Torcher's Trench Coat", type = "Shirt", CharacterId = 3 },
                //Demoman Cosmetics
                new Cosmetic() { id = 7, name = "Scotsman's Stove Pipe", type = "Hat", CharacterId = 4 },
                new Cosmetic() { id = 8, name = "Hurt Locher", type = "Shirt", CharacterId = 4 },
                //Heavy Cosmetics
                new Cosmetic() { id = 9, name = "Officer's Ushanka", type = "Hat", CharacterId = 5 },
                new Cosmetic() { id = 10, name = "Leftover Trap", type = "Beard", CharacterId = 5 },
                //Engineer Cosmetics
                new Cosmetic() { id = 11, name = "The Danger", type = "Hat", CharacterId = 6 },
                new Cosmetic() { id = 12, name = "Gold Digger", type = "Beard", CharacterId = 6 },
                //Medic Cosmetics
                new Cosmetic() { id = 13, name = "Vintage Tyrolean", type = "Hat", CharacterId = 7 },
                new Cosmetic() { id = 14, name = "A Brush with Death", type = "Beard", CharacterId = 7 },
                //Sniper Cosmetics
                new Cosmetic() { id = 15, name = "Professional's Panama", type = "Hat", CharacterId = 8 },
                new Cosmetic() { id = 16, name = "Five-Month Shadow", type = "Beard", CharacterId = 8 },
                //Spy Cosmetics
                new Cosmetic() { id = 17, name = "Fancy Fedora", type = "Hat", CharacterId = 9 },
                new Cosmetic() { id = 18, name = "Megapixel Beard", type = "Beard", CharacterId = 9 }
            );


            base.OnModelCreating(modelBuilder);
        }

        
    }

}
