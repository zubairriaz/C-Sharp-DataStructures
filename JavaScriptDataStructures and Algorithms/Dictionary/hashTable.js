const stringFnEqual = (item) => {
	let returnValue;
	if (item == null) {
		returnValue = "NULL";
	} else if (item == undefined) {
		returnValue = "UNDEFINED";
	} else if (typeof item == "string" || item instanceof String) {
		returnValue = `${item}`;
	} else {
		returnValue = `${item}`;
	}

	return returnValue;
};

class HashTable {
	constructor(defaultEqFn = defaultEqFn) {
		this.strEqFn = defaultEqFn;
		this.table = {};
	}

	put(key, value) {
		if (key != null && value != null) {
			const hash = this.hash(key);
			this.table[hash] = new ValuePair(key, value);
			return true;
		}
		return false;
	}

	remove(key) {
		const hash = this.hash(key);
		if (this.table.hasOwnProperty(hash)) {
			delete this.table[hash];
			return true;
		}
		return false;
	}

	get(key) {
		const hash = this.hash(key);
		if (this.table.hasOwnProperty(hash)) {
			return this.table[hash];
		}
		return false;
	}

	hash(key) {
		return this.looseLooseHash(key);
	}

	looseLooseHash(key) {
		if (typeof key == "number") {
			return key;
		} else {
			let hash = 0;
			const keyHash = this.strEqFn(key);

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

let hashTable = new HashTable(stringFnEqual);
hashTable.put("abc", "abcd");
hashTable.put("bcd", "abcd");

console.log(hashTable.get('abc'))
console.log(hashTable.get('bcd'))


