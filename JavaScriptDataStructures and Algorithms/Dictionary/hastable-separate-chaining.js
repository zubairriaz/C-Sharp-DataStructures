//In separate chaining we use linked list at each position so collision is handled by the linked list
const LinkedListImport = require("../LinkedList/linkedlist");
const LinkedList = LinkedListImport.LinkedList;
const defaultEquals = (a, b) => {
	return a === b;
};
class HashTable {
	constructor() {
		this.table = {};
	}

	put(key, value) {
		if (key != null && value != null) {
			let valuePair = new ValuePair(key, value);
			let hash = this.hash(key);
			if (this.table[hash] == null) {
				this.table[hash] = new LinkedList(defaultEquals);
			}
			this.table[hash].push(valuePair);
			return true;
		}
		return false;
	}

	get(key) {
		let hash = this.hash(key);
		let linkedList = this.table[hash];
        console.log(linkedList , linkedList.isEmpty());
		if (linkedList != null && !linkedList.isEmpty()) {
			let current = linkedList.getHead();
            

			while (current != null) {
				if (current.element.key == key) {
					return current.element;
				}
				current = current.next;
			}
			return true;
		}
		return false;
	}

	remove(key) {
		let hash = this.hash(key);
		let linkedList = this.table[hash];
		if (linkedList != null && !linkedList.isEmpty()) {
			let current = linkedList.getHead();
			while (current.next != null) {
				if (current.element.key == key) {
					linkedList.remove(key);
					if (linkedList.isEmpty()) {
						delete this.table[hash];
					}
					return true;
				}
				current = current.next;
			}
			return false;
		}
	}

	hash(key) {
		return this.looseLooseHash(key);
	}

	looseLooseHash(key) {
		if (typeof key == "number") {
			return key;
		} else {
			let hash = 0;
			const keyHash = key

			for (let i = 0; i < keyHash.length; i++) {
				hash = hash + keyHash.charCodeAt(i);
			}
			return hash % 37;
		}
	}
}

class ValuePair {
	constructor(key, value) {
		this.key = key;
		this.value = value;
	}
}


let has = new HashTable();
has.put('Nathan','abc')
has.put('Sargeras','abc')
has.put('abc','abc')

console.log(has.get('abc'));