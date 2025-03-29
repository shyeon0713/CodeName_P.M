from crewai import Agent, Task,Crew,Process
from crewai_tools import tool
from langchain_openai import ChatOpenAI
from crewai_tools.tools import FileReadTool
import os, requests, re, mdpdf,subprocess
from openai import OpenAI

llm = ChatOpenAI(
    openai_api_base="https://api.groq.com/openai/v1",
    openai_api_key=os.getenv"GROQ_API_KEY",
    model_name="mixtral-8x7b-32768"
)