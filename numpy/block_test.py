import block_module
import datetime

block_chain = []

block = block_module.Block(0, 0, [], '-')

block.proof = block.mining()

block_chain.append(block)

for i in range(20):

    block = block_module.Block(i + 1, str(datetime.datetime.now()), ["トランザクション" + str(i+1)], block_chain[i].now_hash)
    block.proof = block.mining()
    block_chain.append(block)

for block in block_chain:
    for key, value in block.__dict__.items():
        print(key, ':', value)
    print("")


