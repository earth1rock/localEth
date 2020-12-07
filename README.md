Для того, чтобы приложение работало корректно и была возможность синхронизации с Metamask необходимо запускать geth c помощью команды:
geth --mine --http --http.corsdomain "*" --http.api eth,net,web3,personal,web3 --networkid <id> --datadir /path/to/data/dir --allow-insecure-unlock, 
    где <id> - chainId, указанный в первичном блоке (genesis.json)
    
