using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prayer;

namespace UnitTests
{
    [TestClass]
    [TestCategory("Prayer")]
    public class PrayerUnitTests
    {
        [TestMethod]
        public void TestPrayerToString_AllFieldsPresent()
        {
            var prayer = new Prayer.Prayer
            {
                Title = "A Prayer for Peace",
                Author = new Prayer.Author { FirstName = "John", LastName = "Smith" },
                ScriptureReferences = new List<Prayer.ScriptureReference>
                {
                    new Prayer.ScriptureReference { Book = "John", Chapter = 14, StartVerse = 27, EndVerse = 31 }
                },
                Tags = new List<Prayer.Tag>
                {
                    new Prayer.Tag { Name = "Peace" },
                    new Prayer.Tag { Name = "Comfort" },
                    new Prayer.Tag { Name = "Anxiety" }
                }
            };

            string expected = string.Join(Environment.NewLine,
                "A Prayer for Peace",
                "by John Smith",
                "John 14:27-31",
                "Tags: Peace, Comfort, Anxiety");

            Assert.AreEqual(expected, prayer.ToString());
        }

        [TestMethod]
        public void TestPrayerToString_IncludesSubtitleWhenPresent()
        {
            var prayer = new Prayer.Prayer
            {
                Title = "A Prayer for Peace",
                Subtitle = "Finding Calm in Chaos",
                Author = new Prayer.Author { FirstName = "John", LastName = "Smith" }
            };

            string expected = string.Join(Environment.NewLine,
                "A Prayer for Peace",
                "Finding Calm in Chaos",
                "by John Smith");

            Assert.AreEqual(expected, prayer.ToString());
        }

        [TestMethod]
        public void TestPrayerToString_OmitsMissingOptionalFields()
        {
            // No Subtitle, Author, ScriptureReferences, or Tags set.
            var prayer = new Prayer.Prayer { Title = "A Simple Prayer" };

            Assert.AreEqual("A Simple Prayer", prayer.ToString());
        }

        [TestMethod]
        public void TestPrayerToString_JoinsMultipleScriptureReferences()
        {
            var prayer = new Prayer.Prayer
            {
                Title = "A Prayer of Thanks",
                ScriptureReferences = new List<Prayer.ScriptureReference>
                {
                    new Prayer.ScriptureReference { Book = "Psalm", Chapter = 100, StartVerse = 1, EndVerse = 5 },
                    new Prayer.ScriptureReference { Book = "1 Thessalonians", Chapter = 5, StartVerse = 18, EndVerse = 18 }
                }
            };

            string expected = string.Join(Environment.NewLine,
                "A Prayer of Thanks",
                "Psalm 100:1-5, 1 Thessalonians 5:18-18");

            Assert.AreEqual(expected, prayer.ToString());
        }
    }
}
