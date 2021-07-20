### STAGE 1: Build ###
FROM node:latest AS build
WORKDIR /src
#COPY package.json package-lock.json ./
COPY . .
RUN npm install
#COPY . .
RUN npm run build -- --prod

### STAGE 2: Run ###
FROM nginx:alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /src/dist/RpsGameAngular/ /usr/share/nginx/html
#CMD ["nginx", "-g", "daemon off;"]

# FROM node:12.7-alpine AS build
# WORKDIR /usr/src/app
# COPY package.json package-lock.json ./
# RUN npm install
# COPY . .
# RUN npm run build

# ### STAGE 2: Run ###
# FROM nginx:1.17.1-alpine
# COPY nginx.conf /etc/nginx/nginx.conf
# COPY --from=build /usr/src/app/dist/aston-villa-app /usr/share/nginx/html

# FROM node:14.15 as build
# WORKDIR /work/
# COPY . .
# RUN npm clean-install
# RUN npm run build -- --prod

# FROM nginx:alpine
# COPY --from=build /work/nginx.conf /etc/nginx/conf.d/frontend.conf
# COPY --from=build /work/dist/OutOfTheParkAtRevature/ /usr/share/nginx/html/
# CMD ["nginx", "-g", "daemon off;"]