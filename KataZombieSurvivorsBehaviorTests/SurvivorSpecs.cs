using System.Linq;
using Kata_Zombie_Survivors;
using Machine.Specifications;

namespace KataZombieSurvivorsBehaviorTests
{
    [Subject("Survivor creation")]
    public class when_creating_a_survivor
    {
        private static Survivor _survivor;

        private Establish _context = () =>
            _survivor = new Survivor("Arya Stark");

        private It should_have_a_valid_name = () =>
            _survivor.Name.ShouldEqual("Arya Stark");

        private It should_have_no_wounds = () =>
            _survivor.Wounds.ShouldEqual(0u);

        private It should_be_alive = () =>
            _survivor.State.ShouldEqual(SurvivorState.Alive);
    }

    [Subject("Survivor Fighting")]
    public class when_undergo_a_survivor_once_time
    {
        private static Survivor _survivor;

        private Establish _context = () =>
            _survivor = new Survivor("Bronn");

        private Because of = () =>
            _survivor.UndergoWounds();

        private It should_have_one_wounds = () =>
            _survivor.Wounds.ShouldEqual(1u);

        private It should_be_alive = () =>
            _survivor.State.ShouldEqual(SurvivorState.Alive);
    }

    [Subject("Survivor Fighting")]
    public class when_undergo_a_survivor_twice_time
    {
        private static Survivor _survivor;

        private Establish _context = () =>
            _survivor = new Survivor("Bran Stark");

        private Because of = () =>
        {
            _survivor.UndergoWounds();
            _survivor.UndergoWounds();
        };

        private It should_have_two_wounds = () =>
            _survivor.Wounds.ShouldEqual(2u);

        private It should_be_dead = () =>
            _survivor.State.ShouldEqual(SurvivorState.Dead);
    }
    
    [Subject("Survivor Fighting")]
    public class when_undergo_a_died_survivor
    {
        private static Survivor _survivor;

        private Establish _context = () =>
            _survivor = new Survivor("Rickon Stark");

        private Because of = () =>
        {
            _survivor.UndergoWounds();
            _survivor.UndergoWounds();
            //! He is dead now.
            _survivor.UndergoWounds();
        };

        private It should_have_two_wounds = () =>
            _survivor.Wounds.ShouldEqual(2u);

        private It should_be_dead = () =>
            _survivor.State.ShouldEqual(SurvivorState.Dead);
    }
}