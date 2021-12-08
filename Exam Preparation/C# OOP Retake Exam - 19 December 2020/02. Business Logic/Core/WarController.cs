using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> characterParty;
		private List<Item> itemPool;
		public WarController()
		{
			this.characterParty = new List<Character>();
			this.itemPool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];
            switch (characterType)
            {
				case "Priest":
					this.characterParty.Add(new Priest(name));
					break;
				case "Warrior":
					this.characterParty.Add(new Warrior(name));
					break;
				default: throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}
			return string.Format(SuccessMessages.JoinParty, name);
		}
		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
            switch (itemName)
            {
				case "FirePotion":
					this.itemPool.Add(new FirePotion());
					break;
				case "HealthPotion":
					this.itemPool.Add(new HealthPotion());
					break;
				default: throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}
			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}
		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			var currentCharacter = this.characterParty.FirstOrDefault(x => x.Name == characterName);
            if (currentCharacter == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}
            if (this.itemPool.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}
			var item = this.itemPool[itemPool.Count - 1];
			this.characterParty.FirstOrDefault(x => x.Name == characterName).Bag.AddItem(item);
			itemPool.Remove(item);
			return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}
		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			var currentCharacter = this.characterParty.FirstOrDefault(x => x.Name == characterName);
			if (currentCharacter == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}
			var item = currentCharacter.Bag.GetItem(itemName);
			item.AffectCharacter(currentCharacter);
			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}
		public string GetStats()
		{
			var sb = new StringBuilder();
            foreach (var item in characterParty.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
				string status = string.Empty;
                if (item.IsAlive)
                {
					status = "Alive";
				}
                else
                {
					status = "Dead";
				}
				sb.AppendLine($"{item.Name} - HP: {item.Health}/{item.BaseHealth}, AP: {item.Armor}/{item.BaseArmor}, Status: {status}");				
            }
			return sb.ToString().TrimEnd();
		}
		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];
			var attackerCharacter = this.characterParty.FirstOrDefault(x => x.Name == attackerName);
			if (attackerCharacter == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
			var receiverCharacter = this.characterParty.FirstOrDefault(x => x.Name == receiverName);
			if (receiverCharacter == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}
            if (attackerCharacter.GetType().Name != "Warrior")
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
			}
			Warrior attacker = attackerCharacter as Warrior;
			attacker.Attack(receiverCharacter);
			var sb = new StringBuilder();
			sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attackerCharacter.AbilityPoints,
				receiverCharacter.Name, receiverCharacter.Health, receiverCharacter.BaseHealth, receiverCharacter.Armor, receiverCharacter.BaseArmor));
            if (receiverCharacter.IsAlive == false)
            {
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverCharacter.Name));
            }
			return sb.ToString().TrimEnd();
		}
		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];
			var healerCharacter = this.characterParty.FirstOrDefault(x => x.Name == healerName);
			if (healerCharacter == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			var healingReceiverCharacter = this.characterParty.FirstOrDefault(x => x.Name == healingReceiverName);
			if (healingReceiverCharacter == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
			}
			if (healerCharacter.GetType().Name != "Priest")
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}
			Priest healer = healerCharacter as Priest;
			healer.Heal(healingReceiverCharacter);
			var sb = new StringBuilder();
			sb.AppendLine(string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, healerCharacter.AbilityPoints,
				healingReceiverName, healingReceiverCharacter.Health));
			return sb.ToString().TrimEnd();
		}
	}
}
