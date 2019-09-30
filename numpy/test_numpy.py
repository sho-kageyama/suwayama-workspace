#Coding:UTF-8

import chainer
import numpy as np
import sklearn as s
import chainer.functions as F
import chainer.links as L

from chainer import training, iterators
from chainer.training import extensions
from chainer.datasets import tuple_dataset
from chainer import Variable, optimizer, Chain
from sklearn import datasets


a = np.arange(10).reshape(2,5)
x = Variable(a)
print(x.data)
print(a)