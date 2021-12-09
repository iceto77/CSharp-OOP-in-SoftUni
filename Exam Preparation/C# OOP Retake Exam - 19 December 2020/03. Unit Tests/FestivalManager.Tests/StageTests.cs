// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {

        [Test]
        public void PerformersShouldWorkCorectly()
        {
            var stage = new Stage();
            Assert.AreEqual(0, stage.Performers.Count);
        }

        [Test]
        public void MethodAddPerformerThrowExceptionIsAgeLess18()
        {
            var stage = new Stage();
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Ala", "Bala", 5)));
        }

        [Test]
        public void MethodAddPerformerShouldWorkCorectly()
        {
            var stage = new Stage();
            stage.AddPerformer(new Performer("Ala", "Bala", 25));
            Assert.AreEqual(1, stage.Performers.Count);
        }

        [Test]
        public void MethodValidateNullValueThrowException()
        {
            var stage = new Stage();
            Song song = null;
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(song));
        }

        [Test]
        public void MethodGetPerformerThrowException()
        {
            var stage = new Stage();
            stage.AddPerformer(new Performer("Ala", "Bala", 25));
            Song song = new Song("Last Christmas", new TimeSpan(0, 2, 30));
            stage.AddSong(song);
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Last Christmas", "dedo"));
        }

        [Test]
        public void MethodGetSongThrowException()
        {
            var stage = new Stage();
            stage.AddPerformer(new Performer("Ala", "Bala", 25));
            Song song = new Song("Last Christmas", new TimeSpan(0, 2, 30));
            stage.AddSong(song);
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Makarena", "Ala Bala"));
        }

        [Test]
        public void MethodAddSongThrowExceptionIsSongDurationIsLess1minute()
        {
            var stage = new Stage();
            Song song = new Song("Last Christmas", new TimeSpan(0, 0, 30));
            Assert.Throws<ArgumentException>(() => stage.AddSong(song));
        }

        [Test]
        public void MethodAddSongShouldWorkCorectly()
        {
            var stage = new Stage();
            stage.AddPerformer(new Performer("Ala", "Bala", 25));
            Song song = new Song("Last Christmas", new TimeSpan(0, 2, 30));
            stage.AddSong(song);
            string target = $"Last Christmas (02:30) will be performed by Ala Bala";
            string result = stage.AddSongToPerformer("Last Christmas", "Ala Bala");
            Assert.AreEqual(target, result);
        }

        [Test]
        public void MethodPlayShouldWorkCorectly()
        {
            var stage = new Stage();
            stage.AddPerformer(new Performer("Ala", "Bala", 25));
            Song song = new Song("Last Christmas", new TimeSpan(0, 2, 30));
            stage.AddSong(song);
            stage.AddSongToPerformer("Last Christmas", "Ala Bala");
            string target = $"1 performers played 1 songs";
            string result = stage.Play();
            Assert.AreEqual(target, result);
        }


        /*
        [Test]
        public void MethodAddSongShouldWorkCorectly()
        {
            var stage = new Stage();
            stage.AddPerformer(new Performer("Ala", "Bala", 25));
            Song song = new Song("Last Christmas", new TimeSpan(0, 2, 30));
            stage.AddSong(song);
            string target = $"{stage.Performers.Count} performers played 1 songs";
            string result = stage.Play();
            Assert.AreEqual(target, result);
        }

        */



    }
}