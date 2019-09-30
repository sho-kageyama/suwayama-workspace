import hashlib
import json
import _datetime

class Block:
    def __init__(self, index, timestamp, transaction, previous_hash):
        self.index = index
        self.timestamp = timestamp
        self.transaction = transaction
        self.previous_hash = previous_hash
        self.difficulty = 4
        self.property_dict = {str(i): j for i, j in self.__dict__.items()}
        self.now_hash = self.calc_hash()

    def calc_hash(self):
        block_string = json.dumps(self.property_dict, sort_keys=True).encode('ascii')
        return hashlib.sha256(block_string).hexdigest()

def new_transaction(sender, recipient, amount):
    transaction = {
        "差出人": sender,
        "宛先": recipient,
        "金額": amount,
    }
    return transaction

block_chain = []

genesis_block = Block(0, 0, 0, "-")
block_chain.append(genesis_block)

transaction = new_transaction("太郎", "花子", 100)
new_block = Block(1, str(_datetime.datetime.now()), transaction, block_chain[0].now_hash)
block_chain.append(new_block)

for key, value in genesis_block.__dict__.items():
    print(key, ':', value)

print("")

for key, value in new_block.__dict__.items():
    print(key, ':', value)
