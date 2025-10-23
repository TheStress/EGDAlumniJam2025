using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

namespace Bian
{
    public enum RitualItemType
    {
        None,
        Type1,
        Type2,
        Type3,
        Type4,
        Type5
    }

    public class RitualGameManager : MicroGameManager
    {
        public const int itemCount = 5;

        public Color[] itemColors = new Color[itemCount];

        private RitualItem currentHeldItem;

        void Start()
        {

        }

        void Update()
        {

        }

        public override void OnStartMicroGame()
        {

        }
        public override void OnEndMicroGame()
        {

        }

        public RitualItem GetHeldItem()
        {
            return currentHeldItem;
        }

        public RitualItemType GetHeldItemType()
        {
            if (currentHeldItem != null)
            {
                return currentHeldItem.GetItemType();
            }

            return RitualItemType.None;
        }

        public void UpdateHeldItem(RitualItem item)
        {
            currentHeldItem = item;
        }
    }
}
