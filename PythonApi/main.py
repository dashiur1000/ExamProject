from fastapi import FastAPI, HTTPException
from pydantic import BaseModel
from sqlalchemy import create_engine, Table, MetaData
from sqlalchemy.orm import sessionmaker
from typing import List, Optional

MYSQL_URL = "mysql+pymysql://root:root@localhost:3306/exam_db"

engine = create_engine(MYSQL_URL)
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

metadata = MetaData()
metadata.reflect(bind=engine)

app = FastAPI(title="Existing MySQL Table API", version="1.0")

def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@app.get("/api/criticals")
def get_criticals():
    with engine.connect() as connection:
        table = Table("Criticals", metadata, autoload_with=engine)
        result = connection.execute(table.select()).mappings().all()
        return [dict(row) for row in result]


@app.get("/api/criticals/{item_id}")
def get_critical_by_id(item_id: str):
    with engine.connect() as connection:
        table = Table("Criticals", metadata, autoload_with=engine)
        query = table.select().where(table.c.Id == item_id)
        result = connection.execute(query).mappings().first()

        if not result:
            raise HTTPException(status_code=404, detail="Item not found")

        return dict(result)
