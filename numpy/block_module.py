import hashlib
import json
import datetime

class Block:
    def __init__(self, index, timestamp, transaction, previous_hash):
        self.index = index
        self.timestamp = timestamp
        self.transaction = transaction
        self.previous_hash = previous_hash
        self.difficulty = 4
        self.property_dict = {str(i): j for i, j in self.__dict__.items()}
        self.now_hash = self.calc_hash()
        self.proof = None
        self.proof_hash = None

    def check_proof(self, nonce):
        proof_string = self.now_hash + str(nonce)
        calced = hashlib.sha256(proof_string.encode("ascii")).hexdigest()
        if calced[:self.difficulty].count("0") == self.difficulty:
            self.proof_hash = calced
            return True
        else:
            return False

    def mining(self):
        proof = 0
        while True:
            if self.check_proof(proof):
                break
            else:
                proof += 1
        return proof

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
