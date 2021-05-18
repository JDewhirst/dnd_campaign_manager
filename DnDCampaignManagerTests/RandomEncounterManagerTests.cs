using System.Linq;
using NUnit.Framework;
using DnDCampaignManagerApp;
using CampaignManagerData;
using static DnDCampaignManagerApp.Exceptions;



namespace DnDCampaignManagerTests
{
    class RandomEncounterManagerTests
    {
        RandomEncounterManager _randomEncounterManager;
        [SetUp]
        public void Setup()
        {
            _randomEncounterManager = new RandomEncounterManager();
            // remove test entry in DB if present
            using (var db = new DnDCampaignManagerContext())
            {
                var selectedTables = db.RandomEncounters.Where(re => re.RandEncounterTableId == "Olympus Mons");
                db.RandomEncounters.RemoveRange(selectedTables);
                db.SaveChanges();
            }
        }

        [TestCase("1d0")]
        [TestCase("0d1")]
        [TestCase("999")]
        public void WhenAttemptToCreateTableWithIncorrectDiceThrowException(string input)
        {
            Assert.Throws<IncorrectDiceException>(() => _randomEncounterManager.CreateTable("Olympus Mons", input, @"{ '1':'Flying Monkey' }") );
        }
        // Create

        [Test]
        public void WhenNewRandEncTableIsAdded_TheNumberOfRandEncTablesIncreasesBy1()
        {
            using (var db = new DnDCampaignManagerContext())
            {
                var numTables = db.RandomEncounters.Count();
                _randomEncounterManager.CreateTable("Olympus Mons", "1d1", @"{ '1':'Flying Monkey' }");
                var result = db.RandomEncounters.Count();
                Assert.AreEqual(1, result - numTables);
            }
        }

        // Read
        [Test]
        public void GetListOfRandomEncounterTables_ReturnsListLengthEqualToNumberofEntries()
        {
            var result = _randomEncounterManager.GetListOfRandomEncounterTables().Count;
            int expected;
            using (var db = new DnDCampaignManagerContext())
            {
                expected = db.RandomEncounters.Count();
            }
            Assert.AreEqual(expected, result);
        }

        // Update

        [Test]
        public void WhenARandomEncounterTableDiceIsUpdated_ItIsUpdated()
        {
            RandomEncounter newTable = new RandomEncounter() { RandEncounterTableId = "Olympus Mons", Dice = "1d1",RandEncounter = @"{ '1':'Flying Monkey' }" };
            using (var db = new DnDCampaignManagerContext())
            {
                db.RandomEncounters.Add(newTable);
                db.SaveChanges();
            }
            _randomEncounterManager.UpdateTable("Olympus Mons", "1d2", @"{ '1':'Flying Monkey', '2':'Jumping Man' }");
            string result;
            using (var db = new DnDCampaignManagerContext())
            {
                result = db.RandomEncounters.Where(p => p.RandEncounterTableId == "Olympus Mons").FirstOrDefault().Dice;
            }
            Assert.AreEqual("1d2", result);
        }

        [Test]
        public void WhenARandomEncounterTableTableIsUpdated_ItIsUpdated()
        {
            RandomEncounter newTable = new RandomEncounter() { RandEncounterTableId = "Olympus Mons", Dice = "1d1", RandEncounter = @"{ '1':'Flying Monkey' }" };
            using (var db = new DnDCampaignManagerContext())
            {
                db.RandomEncounters.Add(newTable);
                db.SaveChanges();
            }
            _randomEncounterManager.UpdateTable("Olympus Mons", "1d2", @"{ '1':'Flying Monkey', '2':'Jumping Man' }");
            string result;
            using (var db = new DnDCampaignManagerContext())
            {
                result = db.RandomEncounters.Where(p => p.RandEncounterTableId == "Olympus Mons").FirstOrDefault().Dice;
            }
            Assert.AreEqual("1d2", result);
        }

        // Delete
        [Test]
        public void WhenRandomEncounterEntryIsDeleted_TheNumberOfRandEncounterDecreaseBy1()
        {
            RandomEncounter newTable = new RandomEncounter() { RandEncounterTableId = "Olympus Mons", Dice = "1d1", RandEncounter = @"{ '1':'Flying Monkey' }" };
            using (var db = new DnDCampaignManagerContext())
            {
                db.RandomEncounters.Add(newTable);
                db.SaveChanges();
            }
            int preCount;
            int postCount;
            using (var db = new DnDCampaignManagerContext())
            {
                preCount = db.RandomEncounters.Count();
            }
            _randomEncounterManager.Delete("Olympus Mons");
            using (var db = new DnDCampaignManagerContext())
            {
                postCount = db.RandomEncounters.Count();
            }
            Assert.AreEqual(preCount - 1, postCount);
            

        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new DnDCampaignManagerContext())
            {
                var selectedTables = db.RandomEncounters.Where(re => re.RandEncounterTableId == "Olympus Mons");
                db.RandomEncounters.RemoveRange(selectedTables);
                db.SaveChanges();
            }
        }
    }
}
