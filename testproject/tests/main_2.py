from dotenv import load_dotenv
from crewai import Agent, Task, Crew
from langchain.tools.base import Tool
from langchain_community.tools import DuckDuckGoSearchRun

# 환경 변수 로드
load_dotenv()

# DuckDuckGoSearchRun 초기화
search_tool = DuckDuckGoSearchRun()

# 검색 도구 정의
tool = Tool(
    name="DuckDuckGo Search",
    func=lambda query: search_tool.run(tool_input=query),
    description="Search using DuckDuckGo for retrieving up-to-date information."
)

# Groq 모델을 사용하는 에이전트 정의
researcher = Agent(
    role="Senior Research Analyst",
    goal="Uncover cutting-edge developments in AI and data science",
    backstory="""You work at a leading tech think tank.
    Your expertise lies in identifying emerging trends.
    You have a knack for dissecting complex data and presenting
    actionable insights.""",
    verbose=True,
    allow_delegation=False,
    tools=[tool]
)

writer = Agent(
    role="Tech Content Strategist",
    goal="Craft compelling content on tech advancements",
    backstory="""You are a renowned Content Strategist, known for
    your insightful and engaging articles.
    You transform complex concepts into compelling narratives.""",
    verbose=True,
    allow_delegation=False,
)

translator = Agent(
    role="Translator",
    goal="Translate English documents written by the writer into Korean with high accuracy and natural fluency.",
    backstory="""
    A professional translator with extensive experience in translating technical, creative, and general documents. 
    Known for attention to detail and a deep understanding of both English and Korean cultural nuances, 
    ensuring the translated text retains the original intent and style.
    """,
    verbose=True,
    allow_delegation=False
)


# 작업 정의
research = Task(
    description="""Conduct a comprehensive analysis of the latest advancements in AI in 2025.
    Identify key trends, breakthrough technologies, and potential industry impacts.
    Your final answer MUST be a full analysis report""",
    agent=researcher,
    expected_output="A detailed analysis report in text format."
)

write = Task(
    description="""Using the insights provided, develop an engaging blog
    post that highlights the most significant AI advancements.
    Your post should be informative yet accessible, catering to a tech-savvy audience.
    Make it sound cool, avoid complex words so it doesn't sound like AI.
    Your final answer MUST be the full blog post of at least 4 paragraphs.""",
    agent=writer,
    expected_output="A blog post with at least 4 paragraphs in text format."
)

translate = Task(
    description="""
    Translate the given English document into Korean while maintaining the original tone and intent. 
    Ensure the translation is accurate, culturally appropriate, and uses natural Korean expressions. 
    Avoid overly literal translations and focus on conveying the meaning fluently in Korean. 
    The final output MUST be the fully translated document in Korean, formatted appropriately.
    """,
    agent=translator,
    expected_output="A fully translated document in Korean."
)


# 팀 생성
crew = Crew(
    agents=[researcher, writer,translator],
    tasks=[research, write,translate],
    verbose=True
)

# 작업 시작
result = crew.kickoff()
print(result)
