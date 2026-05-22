#!/bin/sh
set -e


# 1. Extract the password from the secret file
if [ -f "$DB_PASSWORD_FILE" ]; 
then
    PASSWORD=$(cat "$DB_PASSWORD_FILE")
else
  if [ "$IS_DEV" = "true" ]
  then
    PASSWORD="$DB_PASSWORD"  
  else
    echo "Error: Password not found for dev : $IS_DEV"
    exit 1
  fi
fi

# 2. Construct the connection string
CONN="Host=$DB_HOST_DOCKER;Port=$DB_PORT;Database=$NEXT_TUTO_DB_NAME;Username=$DB_USER;Password=$PASSWORD;"

echo "Running migrations..."

# 3. Execute the bundle
exec ./migrate --connection "$CONN"
