using System.Collections;
using UnityEngine;

namespace Source.Modules.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}