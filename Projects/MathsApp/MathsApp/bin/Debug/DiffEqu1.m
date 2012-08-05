a = [1, -1.143, 0.4128]; b = [0.0675, 0.1349, 0.675];
x = zeros(1,50);
zi = filtic (b,a, [1,2]);
y = filter(b,a,x,zi);