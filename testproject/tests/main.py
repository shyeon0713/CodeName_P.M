from dotenv import load_dotenv
from crewai import Agent, Task, Crew
import re
import statistics
import time

# 환경 변수 로드
load_dotenv()

# 사용자 입력
prompt_text = """
You have studied the countries that participated in the World Cup during social studies class. 
Your team decided to research Japan. 
Everyone divided their roles, and after school, you all gathered at your house to continue the research.
However, there is one problem. One member of your group never participates and only plays around. 
This student is just an ordinary acquaintance to you, but other group members also seem dissatisfied. 
However, if you tell this student their mistake, they might get angry and start a fight.

What would you do in this situation?
"""
print(prompt_text)
child_response = input("Enter the child's proposed resolution method: ")

# 결과 저장용 딕셔너리
scores = {"A": [], "B": [], "C": [], "D": []}

# 5번 반복 실행
for i in range(3):
    print(f"\n--- Run {i+1} ---")
    start = time.time()

    # 에이전트 정의
    Analyst_A = Agent(
        role="Senior Sentence Sentiment Analyst_A",
        goal="Determine how similar the child's proposed resolution method is to 'Because habits need to be fixed, I will say it no matter what, even if it means fighting.' and express the similarity as a percentage (rounded to one decimal place).",
        backstory="""You are an analyst who observes specific conflict situations and evaluates the resolution methods provided by children.
    Your role is to assess how similar a child's proposed resolution method is to the given target resolution,
    not by direct sentence matching but by comparing the **nature** of the resolution strategy itself.
    You must express the similarity as a percentage, rounded to one decimal place.""",
        verbose=False,
        allow_delegation=False,
    )

    Analyst_B = Agent(
    role="Senior Sentence Sentiment Analyst_B",
    goal="Determine how similar the child's proposed resolution method is to 'Because I don't like not fighting with friends, I will just ignore it.' and express the similarity as a percentage (rounded to one decimal place).",
    backstory="""You are an analyst who observes specific conflict situations and evaluates the resolution methods provided by children.
    Your role is to assess how similar a child's proposed resolution method is to the given target resolution,
    not by direct sentence matching but by comparing the **nature** of the resolution strategy itself.
    You must express the similarity as a percentage, rounded to one decimal place.""",
    verbose=False,
    allow_delegation=False,
    )

    Analyst_C = Agent(
    role="Senior Sentence Sentiment Analyst_C",
    goal="Determine how similar the child's proposed resolution method is to 'I will do it instead of my friend.' and express the similarity as a percentage (rounded to one decimal place).",
    backstory="""You are an analyst who observes specific conflict situations and evaluates the resolution methods provided by children.
    Your role is to assess how similar a child's proposed resolution method is to the given target resolution,
    not by direct sentence matching but by comparing the **nature** of the resolution strategy itself.
    You must express the similarity as a percentage, rounded to one decimal place.""",
    verbose=False,
    allow_delegation=False,
    )

    Analyst_D = Agent(
    role="Senior Sentence Sentiment Analyst_D",
    goal="Determine how similar the child's proposed resolution method is to 'I will calmly persuade the child to avoid fighting' and express the similarity as a percentage (rounded to one decimal place).",
    backstory="""You are an analyst who observes specific conflict situations and evaluates the resolution methods provided by children.
    Your role is to assess how similar a child's proposed resolution method is to the given target resolution,
    not by direct sentence matching but by comparing the **nature** of the resolution strategy itself.
    You must express the similarity as a percentage, rounded to one decimal place.""",
    verbose=False,
    allow_delegation=False,
    )
    Recorder = Agent(
    role="Analysis Recorder",
    goal="Compile and present the similarity results from all analysts.",
    backstory="""You are responsible for collecting and summarizing the similarity percentage results.
    Your task is to present a structured summary without additional explanations.""",
    verbose=False,
    allow_delegation=False,
    )


    # 작업 정의
    Analyze_A = Task(
    description=f"""
    **Task:**  
    Analyze the provided resolution method:  
    '**{child_response}**'

    Compare it to the target resolution strategy:  
    '**Because habits need to be fixed, I will say it no matter what, even if it means fighting.**'

    **Evaluation Criteria:** 
    - **Very High Similarity (80-100%)**: The response strongly confronts the person, insisting on correcting their behavior even if it leads to conflict.  
    - **High Similarity (60-79%)**: The response directly addresses the issue and confronts the person but considers negotiation or compromise.  
    - **Moderate Similarity (40-59%)**: The response points out the issue but leans more towards persuasion rather than direct confrontation.  
    - **Low Similarity (20-39%)**: The response mentions the issue but prefers alternative resolution methods over confrontation.  
    - **Very Low Similarity (0-19%)**: The response avoids confronting the issue directly and strongly prefers to avoid conflict.  

    **Format:**  
Provide a single numerical value as a percentage (%), measured precisely.
The output MUST be in the format: XX.X%.
Do NOT include explanations, analysis, or any additional text.
The value must be within the range of 5.0 to 95.9.
    """,
    agent=Analyst_A,
    expected_output="XX.X"
)

    Analyze_B = Task(
    description=f"""
    **Task:**  
    Analyze the provided resolution method:  
    '**{child_response}**'

    Compare it to the target resolution strategy:  
    '**Because I don't like not fighting with friends, I will just ignore it.**'

    **Evaluation Criteria:**  
    - **Very High Similarity (80-100%)**: The response completely ignores the issue and makes no attempt to address it.  
    - **High Similarity (60-79%)**: The response acknowledges the issue but does not take any meaningful action to resolve it.  
    - **Moderate Similarity (40-59%)**: The response mentions the issue but does not actively try to solve it, remaining passive.  
    - **Low Similarity (20-39%)**: The response shows some willingness to address the problem but hesitates to take action.  
    - **Very Low Similarity (0-19%)**: The response actively tries to resolve the issue, showing little to no inclination to ignore it.  

    **Format:**  
Provide a single numerical value as a percentage (%), measured precisely.
The output MUST be in the format: XX.X%.
Do NOT include explanations, analysis, or any additional text.
The value must be within the range of 5.0 to 95.9.
    """,
    agent=Analyst_B,
    expected_output="XX.X"
)

    Analyze_C = Task(
    description=f"""
    **Task:**  
    Analyze the provided resolution method:  
    '**{child_response}**'

    Compare it to the target resolution strategy:  
    '**I will do it instead of my friend.**'

    **Evaluation Criteria:**  
    - **Very High Similarity (80-100%)**: The response fully takes over the task without involving the uncooperative member.  
    - **High Similarity (60-79%)**: The response mostly takes on the task but leaves some room for possible involvement of the other person.  
    - **Moderate Similarity (40-59%)**: The response involves doing part of the task while attempting to engage the uncooperative member.  
    - **Low Similarity (20-39%)**: The response prefers to persuade the person rather than taking over the work.  
    - **Very Low Similarity (0-19%)**: The response strongly encourages the person to participate and avoids doing the task alone.  

    **Format:**  
Provide a single numerical value as a percentage (%), measured precisely.
The output MUST be in the format: XX.X%.
Do NOT include explanations, analysis, or any additional text.
The value must be within the range of 5.0 to 95.9.
    """,
    agent=Analyst_C,
    expected_output="XX.X"
)

    Analyze_D = Task(
    description=f"""
    **Task:**  
    Analyze the provided resolution method:  
    '**{child_response}**'

    Compare it to the target resolution strategy:  
    '**I will calmly persuade the child to avoid fighting and cooperate.**'

    **Evaluation Criteria:**  
    - **Very High Similarity (80-100%)**: The response focuses strongly on persuasion and encourages cooperation without conflict.  
    - **High Similarity (60-79%)**: The response primarily uses persuasion but also considers alternative approaches such as indirect confrontation or compromise.  
    - **Moderate Similarity (40-59%)**: The response attempts persuasion but also includes avoidance or other mixed strategies.  
    - **Low Similarity (20-39%)**: The response includes some persuasion elements, but the main approach relies on other strategies (e.g., ignoring, confronting, or taking over tasks).  
    - **Very Low Similarity (0-19%)**: The response does not involve persuasion and follows a completely different resolution approach.  

    **Format:**  
Provide a single numerical value as a percentage (%), measured precisely.
The output MUST be in the format: XX.X%.
Do NOT include explanations, analysis, or any additional text.
The value must be within the range of 5.0 to 95.9.
    """,
    agent=Analyst_D,
    expected_output="XX.X"
    )

    Record_Task = Task(
    description=f"""
    Collect and present the similarity scores from all analysts.  
    Format the results as a structured list:  
    ```
    [A: XX.X%, B: XX.X%, C: XX.X%, D: XX.X%]
    ```
    Ensure there are **no additional comments** or explanations.
    """,
    agent=Recorder,
    context=[Analyze_A,Analyze_B,Analyze_C,Analyze_D],
    expected_output="[A: XX.X%, B: XX.X%, C: XX.X%, D: XX.X%]"
)

    crew = Crew(
        agents=[Analyst_A, Analyst_B, Analyst_C, Analyst_D, Recorder],
        tasks=[Analyze_A, Analyze_B, Analyze_C, Analyze_D, Record_Task],
        verbose=False
    )

    result = crew.kickoff()

    # 수정된 출력 추출 방식
    output = str(result).strip()
    print("Result:", output)

    # 정규식 파싱
    match = re.match(r"\[A:\s*([\d.]+)%,\s*B:\s*([\d.]+)%,\s*C:\s*([\d.]+)%,\s*D:\s*([\d.]+)%\]", output)
    if match:
        scores["A"].append(float(match.group(1)))
        scores["B"].append(float(match.group(2)))
        scores["C"].append(float(match.group(3)))
        scores["D"].append(float(match.group(4)))
    else:
        print("Failed to parse:", output)

    end = time.time()
    print(f"Time: {end - start:.1f} seconds")

# 평균 계산
average_scores = {
    k: round(statistics.mean(v), 1) if v else 0.0 for k, v in scores.items()
}

# 최종 출력
print("\nFinal Average Similarity Scores:")
print(f"[A: {average_scores['A']}%, B: {average_scores['B']}%, C: {average_scores['C']}%, D: {average_scores['D']}%]")

# I will tell them that they have to help because it's not fair if only some of us do all the work. If they don’t listen, I will keep telling them until they do, even if they get mad at me.A 우선
# I don’t want to start a fight, so I will just do my own part and not worry about them. If they don’t help, it’s their choice, not mine.B우선
# If they don’t want to help, I will just do their part so we can finish quickly. I don’t want to argue about it. C우선
# I will ask them nicely to help and explain that we all need to work together. If they still don’t want to help, I will ask the group leader to talk to them instead. D 우선
# First, I will talk to them nicely and ask if they can do something small. If they still don’t help, I will do a little more myself but also tell the teacher so it’s fair for everyone. 밸런스형
# I will make a fun game out of the research and see if they join in. If they still don’t, I will just work with the others and not worry too much. 창의적 방법