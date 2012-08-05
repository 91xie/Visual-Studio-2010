figure;
w= pi/5;
n = 1:100;
xn = u(sin(w.*n));
hn = 0.5.^(-n);
theplot = conv(xn,hn);
plot (n,theplot);