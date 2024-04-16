FROM ubuntu:22.04

ENV NODE_VERSION=21

RUN apt-get update && \
    apt-get install -y curl gnupg && \
    curl -fsSL https://deb.nodesource.com/setup_"$NODE_VERSION".x | bash - && \
    apt-get install -y nodejs

RUN apt-get install gnupg curl && \
    curl -fsSL https://www.mongodb.org/static/pgp/server-7.0.asc | \
    gpg -o /usr/share/keyrings/mongodb-server-7.0.gpg \
    --dearmor && \
    echo "deb [ arch=amd64,arm64 signed-by=/usr/share/keyrings/mongodb-server-7.0.gpg ] https://repo.mongodb.org/apt/ubuntu jammy/mongodb-org/7.0 multiverse" | tee /etc/apt/sources.list.d/mongodb-org-7.0.list && \
    apt-get update && \
    apt-get install -y mongodb-org && \
    echo "mongodb-org hold" | dpkg --set-selections && \
    echo "mongodb-org-database hold" | dpkg --set-selections && \
    echo "mongodb-org-server hold" | dpkg --set-selections && \
    echo "mongodb-mongosh hold" | dpkg --set-selections && \
    echo "mongodb-org-mongos hold" | dpkg --set-selections && \
    echo "mongodb-org-tools hold" | dpkg --set-selections 

RUN mkdir -p /data/db

WORKDIR /app

COPY ./dist /app/dist
COPY ./.env /app/

COPY package*.json /app/

RUN npm install

EXPOSE 3001

CMD mongod --fork --logpath /var/log/mongodb.log --bind_ip_all --port 27017 && npm run start:prod