import matplotlib.pyplot as plt
import numpy as np

data_f = open('report.csv')

scores = []

categories = []

for line in data_f:
    (name, hp) = line.split(',')
    scores.append(int(hp))
    categories.append(name)

data_f.close()

scores = [*scores, scores[0]]
categories = [*categories, categories[0]]

label_loc = np.linspace(start = 0, stop = 2*np.pi, num = len(scores))


plt.figure(figsize = (7,7))

ax = plt.subplot(polar = True)

plt.xticks(label_loc, labels = categories, fontsize = 13)
ax.plot(label_loc, scores, label = 'Student1', linestyle = 'dashed', color = 'lightcoral')
ax.fill(label_loc, scores, color = 'lightcoral', alpha = 0.3)
ax.legend()


fig = plt.gcf()
fig.savefig("Test.png")
plt.show()
