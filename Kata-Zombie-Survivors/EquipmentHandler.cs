using System.Collections.Generic;
using System.Linq;

namespace Kata_Zombie_Survivors
{
    public class EquipmentHandler
    {
        public int Capacity() => _inHandEquipments.Capacity + _inReserveEquipments.Capacity;
        public int NbEquipments() => _inHandEquipments.Count + _inReserveEquipments.Count;

        public bool IsFull() => NbEquipments() == Capacity();

        public bool ReduceCapacity()
        {
            if (Capacity() > 0)
            {
                if (_inReserveEquipments.Count < _inReserveEquipments.Capacity)
                {
                    //! If we have enough place but all slot are not taken we just have to reduce the capacity
                    _inReserveEquipments.Capacity -= 1;
                    return true;
                }

                if (_inReserveEquipments.Count == _inReserveEquipments.Capacity && _inReserveEquipments.Any())
                {
                    _inReserveEquipments.RemoveAt(_inReserveEquipments.Count - 1);
                    _inReserveEquipments.Capacity -= 1;
                    return true;
                }


                if (_inHandEquipments.Count < _inHandEquipments.Capacity)
                {
                    //! Same as above
                    _inHandEquipments.Capacity -= 1;
                    return true;
                }

                if (_inHandEquipments.Count == _inHandEquipments.Capacity && _inHandEquipments.Any())
                {
                    _inHandEquipments.RemoveAt(_inHandEquipments.Count - 1);
                    _inHandEquipments.Capacity -= 1;
                    return true;
                }
            }
            return false;
        }

        public bool AddEquipment(Equipment equipment)
        {
            if (_inHandEquipments.Count < EquipementsInHandMaxCapacity)
            {
                _inHandEquipments.Insert(_inHandEquipments.Count, equipment);
                return true;
            }

            if (_inReserveEquipments.Count < EquipementsInReserveMaxCapacity)
            {
                _inReserveEquipments.Insert(_inReserveEquipments.Count, equipment);
                return true;
            }

            return false;
        }

        public bool AddEquipments(params Equipment[] equipments)
        {
            return equipments.Aggregate(true, (current, equipment) => current & AddEquipment(equipment));
        }

        private const int EquipementsInHandMaxCapacity = 2;
        private const int EquipementsInReserveMaxCapacity = 3;
        private readonly List<Equipment> _inHandEquipments = new List<Equipment>(EquipementsInHandMaxCapacity);
        private readonly List<Equipment> _inReserveEquipments = new List<Equipment>(EquipementsInReserveMaxCapacity);
    }
}