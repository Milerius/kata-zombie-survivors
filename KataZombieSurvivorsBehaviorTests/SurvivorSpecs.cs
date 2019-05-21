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
}