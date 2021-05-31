//In linear probing we increment index if there is a collision
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
				this.table[hash] = valuePair;
			} else {
				let index = hash;
				while (this.table[hash] != null) {
					index++;
				}
				this.table[index] = valuePair;
			}

			return true;
		}
		return false;
	}

	get(key) {
		let hash = this.hash(key);
		if (this.table[hash] != null && this.table[hash].key != key) {
			let index = hash;
			while (this.table[index] != null && this.table[index].key != key) {
				index++;
			}
			if (this.table[index] != null && this.table[index].key == key) {
				return this.table[index];
			}
		} else if (this.table[hash] != null && this.table[hash].key == key) {
			return this.table[hash].key;
		}

		return false;
	}

	remove(key) {
		let hash = this.hash(key);
		if (this.table[hash] != null) {
			if (this.table[hash].key == key) {
				delete this.table[hash];
				this.verifyRemoveSideEffects(hash, key);
				return true;
			}
			let index = hash + 1;
			while (this.table[index] != null && this.table[index].key != key) {
				index++;
			}
			if (this.table[index] != null && this.table[index].key == key) {
				delete this.table[index];
				this.verifyRemoveSideEffects(index, key);
				return true;
			}
		}
		return false;
	}

	verifyRemoveSideEffects(position, key) {
		const hash = this.hash(key);
		let index = position + 1;
		while (this.table[index] != null) {
			const posHash = this.hash(this.table[index].key);
			if (posHash <= hash || posHash <= position) {
				this.table[position] = this.table[index];
				delete this.table[index];
				position = index;
			}
			index++;
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
			const keyHash = key;

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
has.put("Nathan", "abc");
has.put("Sargeras", "abc");
has.put("abc", "abc");

console.log(has.get("abc"));
