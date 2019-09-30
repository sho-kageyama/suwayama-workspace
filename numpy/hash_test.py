import hashlib

prevhash = '2019-09-30 16:28:18.260599' + str(1)
hash = hashlib.sha256(prevhash.encode("ascii")).hexdigest()
print(hash)