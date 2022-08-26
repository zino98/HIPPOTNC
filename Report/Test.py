import numpy as np
import matplotlib.pyplot as plt

categories = ['Korean','Math','English','Music','Science']
categories = [*categories, categories[0]]

grade1 = [94,79,65,74,91]

grade1 = [*grade1, grade1[0]]

label_loc = np.linspace(start = 0, stop = 2*np.pi, num = len(grade1))

plt.figure(figsize = (8,8))

ax = plt.subplot(polar = True)

plt.xticks(label_loc, labels = categories, fontsize = 13)
ax.plot(label_loc, grade1, label = 'Student1', linestyle = 'dashed', color = 'violet')
ax.fill(label_loc, grade1, color = 'violet', alpha = 0.3)
ax.legend()

plt.show()

