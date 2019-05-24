using Kata_Zombie_Survivors;
using Machine.Specifications;

namespace KataZombieSurvivorsBehaviorTests
{
    public class EquipmentHandlerFixture
    {
        protected static EquipmentHandler EquipmentHandler = new EquipmentHandler();
    }

    [Subject("Equipment handler")]
    public class when_creating_a_equipment_handler : EquipmentHandlerFixture
    {
        private It should_have_a_capacity_of_five = () =>
            EquipmentHandler.Capacity().ShouldEqual(5);

        private It should_have_zero_equipments = () =>
        {
            EquipmentHandler.NbEquipments().ShouldEqual(0);
            EquipmentHandler.IsFull().ShouldBeFalse();
        };
    }

    [Subject("Equipment handler")]
    public class when_equip_an_equipment : EquipmentHandlerFixture
    {
        private static bool _equipmentSuccessfullyWear = false;
        private Establish _context = () => { EquipmentHandler = new EquipmentHandler(); };

        private Because of = () =>
            _equipmentSuccessfullyWear = EquipmentHandler.AddEquipment(Equipment.Molotov);

        private It should_have_absolutely_no_problem = () =>
            _equipmentSuccessfullyWear.ShouldBeTrue();

        private It should_have_now_one_equipment = () =>
            EquipmentHandler.NbEquipments().ShouldEqual(1);

        private It should_not_be_full = () =>
            EquipmentHandler.IsFull().ShouldBeFalse();
    }

    [Subject("Equipment handler")]
    public class when_fully_equip_hand : EquipmentHandlerFixture
    {
        private static bool _equipmentSuccessfullyWear = false;
        private Establish _context = () => { EquipmentHandler = new EquipmentHandler(); };

        private Because of = () =>
            _equipmentSuccessfullyWear = EquipmentHandler.AddEquipments(Equipment.Molotov, Equipment.Katana);

        private It should_have_absolutely_no_problem = () =>
            _equipmentSuccessfullyWear.ShouldBeTrue();

        private It should_have_now_two_equipment = () =>
            EquipmentHandler.NbEquipments().ShouldEqual(2);

        private It should_not_be_full = () =>
            EquipmentHandler.IsFull().ShouldBeFalse();
    }

    [Subject("Equipment handler")]
    public class when_fully_equip_equipment_handler : EquipmentHandlerFixture
    {
        private static bool _equipmentSuccessfullyWear = false;
        private Establish _context = () => { EquipmentHandler = new EquipmentHandler(); };

        private Because of = () =>
            _equipmentSuccessfullyWear = EquipmentHandler.AddEquipments(Equipment.Molotov, Equipment.Katana,
                Equipment.Pistol, Equipment.BatBaseball, Equipment.BottledWater);

        private It should_have_absolutely_no_problem = () =>
            _equipmentSuccessfullyWear.ShouldBeTrue();

        private It should_have_now_five_equipment = () =>
            EquipmentHandler.NbEquipments().ShouldEqual(EquipmentHandler.Capacity());

        private It should_be_full = () =>
            EquipmentHandler.IsFull().ShouldBeTrue();
    }

    [Subject("Equipment handler")]
    public class when_add_to_a_fully_equipment_handler : EquipmentHandlerFixture
    {
        private static bool _equipmentSuccessfullyWear = false;
        private Establish _context = () => { EquipmentHandler = new EquipmentHandler(); };

        private Because of = () =>
            _equipmentSuccessfullyWear = EquipmentHandler.AddEquipments(Equipment.Molotov, Equipment.Katana,
                Equipment.Pistol, Equipment.BatBaseball, Equipment.BottledWater, Equipment.FryingPan);

        private It should_be_to_much_equipment = () =>
            _equipmentSuccessfullyWear.ShouldBeFalse();

        private It should_have_now_five_equipment = () =>
            EquipmentHandler.NbEquipments().ShouldEqual(EquipmentHandler.Capacity());

        private It should_be_full = () =>
            EquipmentHandler.IsFull().ShouldBeTrue();
    }

    [Subject("Equipment handler")]
    public class when_remove_an_equipment_from_hand : EquipmentHandlerFixture
    {
        private static bool _equipmentSuccessfullyRemoved = false;

        private Establish _context = () =>
        {
            EquipmentHandler = new EquipmentHandler();
            EquipmentHandler.AddEquipments(Equipment.Molotov, Equipment.Katana, Equipment.Pistol,
                Equipment.BatBaseball);
        };

        private Because of = () =>
        {
            EquipmentHandler.ReduceCapacity();
            EquipmentHandler.ReduceCapacity();
            EquipmentHandler.ReduceCapacity();
            _equipmentSuccessfullyRemoved = EquipmentHandler.ReduceCapacity();
        };

        private It equipment_should_be_removed = () =>
            _equipmentSuccessfullyRemoved.ShouldBeTrue();

        private It should_still_have_1_equipment_and_a_capacity_of_one = () =>
        {
            EquipmentHandler.NbEquipments().ShouldEqual(1);
            EquipmentHandler.Capacity().ShouldEqual(1);
        };

        private It should_not_be_full = () =>
            EquipmentHandler.IsFull().ShouldBeTrue();
    }

    [Subject("Equipment handler")]
    public class when_remove_equipment_from_reserve_that_is_not_full : EquipmentHandlerFixture
    {
        private static bool _equipmentSuccessfullyRemoved = false;

        private Establish _context = () =>
        {
            EquipmentHandler = new EquipmentHandler();
            EquipmentHandler.AddEquipments(Equipment.Molotov, Equipment.Katana, Equipment.Pistol,
                Equipment.BatBaseball);
        };

        private Because of = () =>
            _equipmentSuccessfullyRemoved = EquipmentHandler.ReduceCapacity();

        private It equipment_should_be_removed = () =>
            _equipmentSuccessfullyRemoved.ShouldBeTrue();

        private It should_still_have_4_equipment_but_a_capacity_of_four = () =>
        {
            EquipmentHandler.NbEquipments().ShouldEqual(4);
            EquipmentHandler.Capacity().ShouldEqual(4);
        };

        private It should_be_full = () =>
            EquipmentHandler.IsFull().ShouldBeTrue();
    }

    [Subject("Equipment handler")]
    public class when_remove_equipment_from_reserve_that_is_full : EquipmentHandlerFixture
    {
        private static bool _equipmentSuccessfullyRemoved = false;

        private Establish _context = () =>
        {
            EquipmentHandler = new EquipmentHandler();
            EquipmentHandler.AddEquipments(Equipment.Molotov, Equipment.Katana, Equipment.Pistol,
                Equipment.BatBaseball, Equipment.BottledWater);
        };

        private Because of = () =>
            _equipmentSuccessfullyRemoved = EquipmentHandler.ReduceCapacity();

        private It equipment_should_be_removed = () =>
            _equipmentSuccessfullyRemoved.ShouldBeTrue();

        private It should_have_4_equipment_and_a_capacity_of_four = () =>
        {
            EquipmentHandler.NbEquipments().ShouldEqual(4);
            EquipmentHandler.Capacity().ShouldEqual(4);
        };

        private It should_be_full = () =>
            EquipmentHandler.IsFull().ShouldBeTrue();
    }


    [Subject("Equipment handler")]
    public class when_remove_an_equipment_from_empty_equipment_handler : EquipmentHandlerFixture
    {
        private static bool _equipmentSuccessfullyReduced = false;
        private Establish _context = () => { EquipmentHandler = new EquipmentHandler(); };

        private Because of = () =>
            _equipmentSuccessfullyReduced = EquipmentHandler.ReduceCapacity();

        private It capacity_should_be_reduced = () =>
            _equipmentSuccessfullyReduced.ShouldBeTrue();

        private It should_have_now_3_equipment = () =>
            EquipmentHandler.NbEquipments().ShouldEqual(0);

        private It should_not_be_full = () =>
            EquipmentHandler.IsFull().ShouldBeFalse();
    }

    [Subject("Equipment handler")]
    public class when_remove_multiple_equipment_from_empty_equipment_handler : EquipmentHandlerFixture
    {
        private static bool _equipmentSuccessfullyReduced = false;
        private Establish _context = () => { EquipmentHandler = new EquipmentHandler(); };

        private Because of = () =>
        {
            EquipmentHandler.ReduceCapacity();
            EquipmentHandler.ReduceCapacity();
            EquipmentHandler.ReduceCapacity();
            EquipmentHandler.ReduceCapacity();
            EquipmentHandler.ReduceCapacity();
            _equipmentSuccessfullyReduced = EquipmentHandler.ReduceCapacity();
        };

        private It should_be_not_reducable_anymore = () => { EquipmentHandler.Capacity().ShouldEqual(0); };
    }
}