import matplotlib.pyplot as plt

data_f = open('report.csv')

scores = []

categories = []

for line in data_f:
    (name, hp, mp, damage, armor, k) = line.split(',')
    scores.append(int(hp))
    categories.append(name)

data_f.close()

fig = plt.figure()
ax = fig.add_subplot(1,1,1)

plt.bar(categories, scores, 0.3, color = "red")

plt.ylabel("Score")
plt.xlabel("Test")

fig = plt.gcf()
fig.savefig("Test.png")
plt.show()
